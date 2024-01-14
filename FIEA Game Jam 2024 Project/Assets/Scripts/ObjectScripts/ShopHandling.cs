using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandling : MonoBehaviour
{
    public bool[] available = new bool[5];
    public GameObject[] UIElements = new GameObject[5];
    public GameObject[] UIHolder = new GameObject[5];
    private GameObject[] instantiatedUI = new GameObject[5];
    public GameObject levelBuilder;
    public int moneySpent;
    // Start is called before the first frame update
    void Start()
    {
        levelBuilder = gameObject;
        moneySpent = 0;

        // Instantiate UI holders
        for (int i = 0; i < 5; i++)
        {
            Instantiate(UIHolder[i], new Vector3(100 * (i + 1), 100, 0), Quaternion.identity, levelBuilder.transform);
        }

        // Populate holders
        for (int i = 0; i < 5; i++)
        {
            if (available[i])
            {
                instantiatedUI[i] = Instantiate(UIElements[i], new Vector3(100 * (i + 1), 100, 0), Quaternion.identity, levelBuilder.transform);
            }
        }
    }
    public void InstantiateNewUISprite(int spotIndex)
    {
        if (available[spotIndex] == false)
        {
            available[spotIndex] = true;
            instantiatedUI[spotIndex] = Instantiate(UIElements[spotIndex], new Vector3(100 * (spotIndex + 1), 100, 0), Quaternion.identity, levelBuilder.transform);
            Debug.Log("UI Sprite Instantiated at index: " + spotIndex);
        }
    }
}
