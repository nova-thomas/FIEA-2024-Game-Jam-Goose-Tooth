using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenGasBehavior : MonoBehaviour
{
    public GameObject ship;
    float dragForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.Find("Ship");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody shipRb = ship.GetComponent<Rigidbody>();

        float columnRange = 5f;
        float columnWidth = 5f;
        float shipZPos = ship.transform.position.z;
        float shipXPos = ship.transform.position.x;
        if (Mathf.Abs(shipZPos - transform.position.z) < columnRange &&
            Mathf.Abs(shipXPos - transform.position.x) < columnWidth)
        {
            shipRb.AddForce(shipRb.velocity.normalized * dragForce, ForceMode.Force);
        }
    }
}
