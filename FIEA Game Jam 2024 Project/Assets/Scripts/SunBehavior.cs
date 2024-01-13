using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehavior : MonoBehaviour
{
    public float force = 1;
    public Rigidbody rb;
    public GameObject ship;

    // Update is called once per frame
    void FixedUpdate()
    {
        SolarWind();
    }

    // Applying Solar Wind Force
    void SolarWind()
    {
        Vector3 direction = rb.position - ship.transform.position;
        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * ship.GetComponent<Rigidbody>().mass) / Mathf.Pow(distance, 2);
        Vector3 solarForce = -direction.normalized * forceMagnitude;
        ship.GetComponent<Rigidbody>().AddForce(solarForce);
    }
}
