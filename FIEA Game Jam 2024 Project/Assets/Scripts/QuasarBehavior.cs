using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuasarBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject ship;

    private void Start()
    {
        ship = GameObject.Find("Ship");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        QuasarPush();
    }

    // Applying Solar Wind Force

    void QuasarPush()
    {
        float localColumnRange = 10f;
        float columnWidth = 2f;
        float pushStrength = 10f;

        // Get the local position of the ship in the quasar's local space
        Vector3 localShipPosition = transform.InverseTransformPoint(ship.transform.position);

        // Check if the ship is within the local range
        if (Mathf.Abs(localShipPosition.z) < localColumnRange &&
            Mathf.Abs(localShipPosition.x) < columnWidth)
        {
            // Apply force based on the ship's relative position
            Vector3 pushForce = new Vector3(localShipPosition.x, 0f, localShipPosition.z).normalized * pushStrength;

            // Apply the force to the ship
            ship.GetComponent<Rigidbody>().AddForce(pushForce);
        }
    }
}