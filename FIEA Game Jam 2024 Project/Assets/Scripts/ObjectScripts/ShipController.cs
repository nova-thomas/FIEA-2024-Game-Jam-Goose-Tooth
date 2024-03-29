using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour



{

    AudioSource m_MyAudioSource;



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


        m_MyAudioSource = GetComponent<AudioSource>();


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
            m_MyAudioSource.Play();
            onStopScr.onStopClick();
        }
        if (collision.gameObject.CompareTag("Wormhole"))
        {
            Debug.Log("WIN YOU STUPID IDIOT");
            onStopScr.onStopClick();
            WinScreen.SetActive(true);
        }
    }
}
