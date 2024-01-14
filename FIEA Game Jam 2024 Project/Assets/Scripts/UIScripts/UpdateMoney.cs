using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoney : MonoBehaviour
{
    public Text uiText;

    private void Start()
    {
        uiText.text = "0";
    }

    public void UpdateUIText(int money)
    {
        if (uiText != null)
        {
            uiText.text = $"{money}";
        }
    }
}
