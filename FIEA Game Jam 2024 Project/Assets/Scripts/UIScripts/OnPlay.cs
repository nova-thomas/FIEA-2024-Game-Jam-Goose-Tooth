using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlay : MonoBehaviour
{
    public DragDropManager dragDropManager;
    public bool gameInProgress = false;
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
        if (!gameInProgress)
        {
            // Adding prefabs to playfield
            dragDropManager.InstantiatePrefabAtPointOnAll();

            // Hide UI Sprites
            foreach (DragDrop draggedSprite in dragDropManager.draggedSprites)
            {
                if (draggedSprite != null)
                {
                    draggedSprite.gameObject.SetActive(false);
                }
            }

            // Set the game in progress
            gameInProgress = true;
        }

    }
}