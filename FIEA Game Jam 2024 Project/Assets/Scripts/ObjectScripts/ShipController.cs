using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Vector3 lastPos;
    private Rigidbody rb;
    private GameObject onStopObj;
    private OnStop onStopScr;
    private GameObject WinScreen;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        rb = GetComponent<Rigidbody>();
        onStopObj = GameObject.Find("Stop");
        onStopScr = onStopObj.GetComponent<OnStop>();
        WinScreen = GameObject.Find("WinScreen");
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
            transform.right = -moveDirection;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kill"))
        {
            onStopScr.onStopClick();
        }
        if (collision.gameObject.CompareTag("Wormhole"))
        {
            WinScreen.SetActive(true);
        }
    }
}
