using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GoToLevel7 : MonoBehaviour
{
    public void SwitchToLevel()
    {
        SceneManager.LoadScene("Level 7");
    }
}
