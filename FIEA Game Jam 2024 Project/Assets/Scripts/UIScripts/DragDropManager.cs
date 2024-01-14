using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropManager : MonoBehaviour
{
    public List<DragDrop> draggedSprites = new List<DragDrop>();

    public void InstantiatePrefabAtPointOnAll(Vector3 pos)
    {
        foreach (DragDrop scriptInstance in draggedSprites)
        {
            if (scriptInstance != null)
            {
                scriptInstance.InstantiatePrefabAtPoint(pos);
            }
        }
    }
}
