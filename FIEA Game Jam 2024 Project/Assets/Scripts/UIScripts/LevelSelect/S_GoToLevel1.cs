using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GoToLevel1 : MonoBehaviour
{
    public void SwitchToLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
}