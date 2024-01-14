using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class ShopHandling : MonoBehaviour
{
    public bool[] available = new bool[5];
    public GameObject[] UIElements = new GameObject[5];
    public GameObject[] UIHolder = new GameObject[5];
    public GameObject[] instantiatedUI = new GameObject[5];
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
            Transform childTransform = transform.Find("ObjectHolder" + GetObjectNameByIndex(i));

            if (childTransform != null)
            {
                UIHolder[i] = childTransform.gameObject;
                Instantiate(UIHolder[i], new Vector3(100 * (i + 1), 100, 0), Quaternion.identity, levelBuilder.transform);
            }
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
    private string GetObjectNameByIndex(int index)
    {
        // Map index to object name
        switch (index)
        {
            case 0:
                return "Sun";
            case 1:
                return "BlackHole";
            case 2:
                return "Quasar";
            case 3:
                return "Nebula";
            case 4:
                return "Hydrogen";
            default:
                return "";
        }
    }
    public int GetObjectIndexByName(string objectNameWithVariations)
    {
        Match match = Regex.Match(objectNameWithVariations, @"^([a-zA-Z]+)");

        if (match.Success)
        {
            string coreObjectName = match.Groups[1].Value;
            switch (coreObjectName)
            {
                case "SunUI":
                    return 0;
                case "BlackHoleUI":
                    return 1;
                case "QuasarUI":
                    return 2;
                case "NebulaUI":
                    return 3;
                case "HydrogenUI":
                    return 4;
                default:
                    return -1; // Handle invalid name
            }
        }
        else
        {
            return -1;
        }
    }

    public void InstantiateUIElement(int index, Vector3 originalPosition)
    {
        if (index >= 0 && index < instantiatedUI.Length && index < available.Length && index < UIElements.Length)
        {
            instantiatedUI[index] = Instantiate(UIElements[index], originalPosition, Quaternion.identity, levelBuilder.transform);
        }
        else
        {
            Debug.LogError("Invalid index: " + index);
        }
    }
}
