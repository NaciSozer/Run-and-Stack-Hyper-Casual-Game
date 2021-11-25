using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishControl : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Level 0");
        PlayerPrefs.DeleteAll();
    }

}
