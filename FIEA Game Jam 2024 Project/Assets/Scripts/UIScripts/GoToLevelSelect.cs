using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevelSelect : MonoBehaviour
{
    public void SwitchToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
