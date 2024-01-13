using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Vector3 lastPos;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Time.fixedDeltaTime != 0)
        {
            moveDirection = (transform.position - lastPos) / Time.fixedDeltaTime;
        }
        if (moveDirection != Vector3.zero)
        {
            moveDirection.Normalize();
            transform.forward = moveDirection;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kill"))
        {
            // Fail level
        }
    }
}
