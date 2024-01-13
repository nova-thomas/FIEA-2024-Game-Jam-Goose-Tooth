using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection = transform.position - lastPos;

        if (moveDirection != Vector3.zero)
        {
            moveDirection.Normalize();
            transform.forward = moveDirection;
        }
    }
}
