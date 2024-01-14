using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlay : MonoBehaviour
{
    public DragDropManager dragDropManager;
    private void Start()
    {
        GameObject playObject = GameObject.Find("LevelHandler");
        if (playObject != null)
        {
            dragDropManager = playObject.GetComponent<DragDropManager>();
        }
    }
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
    public void onPlayClick()
    {
        // Adding prefabs to playfield
        foreach (DragDrop draggedSprite in dragDropManager.draggedSprites)
        {
            Vector3 spawnPosition = GetSpawnPosition(draggedSprite.rectTransform);
            dragDropManager.InstantiatePrefabAtPointOnAll(spawnPosition);
        }
        // Hide UI Sprites
        foreach (DragDrop draggedSprite in dragDropManager.draggedSprites)
        {
            if (draggedSprite != null)
            {
                draggedSprite.gameObject.SetActive(false);
            }
        }
    }
    
}
