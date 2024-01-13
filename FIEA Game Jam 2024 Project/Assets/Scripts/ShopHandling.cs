using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandling : MonoBehaviour
{
    public bool[] available = new bool[5];
    public GameObject[] UIElements = new GameObject[5];
    public GameObject[] UIHolder = new GameObject[5];
    public GameObject levelBuilder;
    public int moneySpent;
    // Start is called before the first frame update
    void Start()
    {
        levelBuilder = gameObject;
        moneySpent = 0;
        Instantiate(UIHolder[0], new Vector3(100, 100, 0), Quaternion.identity, levelBuilder.transform);
        Instantiate(UIHolder[1], new Vector3(250, 100, 0), Quaternion.identity, levelBuilder.transform);
        Instantiate(UIHolder[2], new Vector3(400, 100, 0), Quaternion.identity, levelBuilder.transform);
        Instantiate(UIHolder[3], new Vector3(550, 100, 0), Quaternion.identity, levelBuilder.transform);
        Instantiate(UIHolder[4], new Vector3(700, 100, 0), Quaternion.identity, levelBuilder.transform);
        // Populate holders
        if (available[0] == true)
        {
            Instantiate(UIElements[0], new Vector3(100, 100, 0), Quaternion.identity, levelBuilder.transform);
        } 
        if (available[1] == true)
        {
            Instantiate(UIElements[1], new Vector3(250, 100, 0), Quaternion.identity, levelBuilder.transform);
        }
        if (available[2] == true)
        {
            Instantiate(UIElements[2], new Vector3(400, 100, 0), Quaternion.identity, levelBuilder.transform);
        }
        if (available[3] == true)
        {
            Instantiate(UIElements[3], new Vector3(550, 100, 0), Quaternion.identity, levelBuilder.transform);
        }
        if (available[4] == true)
        {
            Instantiate(UIElements[4], new Vector3(700, 100, 0), Quaternion.identity, levelBuilder.transform);
        }
    }
}
