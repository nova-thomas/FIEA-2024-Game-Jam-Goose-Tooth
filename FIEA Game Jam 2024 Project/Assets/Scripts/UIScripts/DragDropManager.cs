using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropManager : MonoBehaviour
{
    public List<DragDrop> draggedSprites = new List<DragDrop>();
    public List<GameObject> instantiatedObjects = new List<GameObject>();

    public Vector3 GetSpawnPosition(RectTransform rectTransform)
    {
        // Use ray to find the position based on the individual dragged sprite
        Ray ray = Camera.main.ScreenPointToRay(rectTransform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("PlayField"))
        {
            Debug.DrawRay(ray.origin, ray.direction * 200f, Color.red);
            float fixedY = 0f;
            Vector3 spawnPos = new Vector3(hit.point.x, fixedY, hit.point.z);
            return spawnPos;
        }
        Debug.Log("Spawn Position: Not Hit");
        // If raycast doesn't hit the playfield, return Vector3.zero or handle accordingly
        return Vector3.zero;
    }
    public void InstantiatePrefabAtPointOnAll()
    {
        foreach (DragDrop scriptInstance in draggedSprites)
        {
            if (scriptInstance != null)
            {
                Vector3 spawnPosition = GetSpawnPosition(scriptInstance.rectTransform);
                if (spawnPosition != Vector3.zero)
                {
                    GameObject instantiatedObject = Instantiate(scriptInstance.prefabToInstantiate, spawnPosition, Quaternion.identity);
                    instantiatedObjects.Add(instantiatedObject);
                }
            }
        }
    }
}
