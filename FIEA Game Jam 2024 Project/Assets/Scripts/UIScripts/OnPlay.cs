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

    public void onPlayClick()
    {
        // Adding prefabs to playfield
        dragDropManager.InstantiatePrefabAtPointOnAll();

        // Remove sprites from UI
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
