using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStop : MonoBehaviour
{
    GameObject ship;
    public Vector3 startingPos;
    public Rigidbody shipRB;
    void Start()
    {
        ship = GameObject.Find("Ship");
        startingPos = ship.GetComponent<Rigidbody>().position;
        shipRB = ship.GetComponent<Rigidbody>();
    }
    public void onStopClick()
    {
        // Reset Ship
        ship.transform.position = startingPos;
        shipRB.velocity = Vector3.zero;

        // Delete Objects

        // Place UI Sprites Down
    }
}