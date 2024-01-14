using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStop : MonoBehaviour
{
    GameObject ship;
    public Vector3 startingPos;
    public Rigidbody shipRB;
    private DragDropManager dragDropManager;
    void Start()
    {
        ship = GameObject.Find("Ship");
        startingPos = ship.GetComponent<Rigidbody>().position;
        shipRB = ship.GetComponent<Rigidbody>();
        dragDropManager = FindObjectOfType<DragDropManager>();
    }
    public void onStopClick()
    {
        // Reset Ship
        ship.transform.position = startingPos;
        shipRB.velocity = Vector3.zero;

        // Delete Objects
        foreach (GameObject obj in dragDropManager.instantiatedObjects)
        {
            Destroy(obj);
        }
        dragDropManager.instantiatedObjects.Clear();
        // Unhide UI Sprites
        foreach (DragDrop draggedSprite in dragDropManager.draggedSprites)
        {
            if (draggedSprite != null)
            {
                draggedSprite.gameObject.SetActive(true);
            }
        }
    }
}