using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlHomePage : MonoBehaviour
{
    private void Awake()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        Application.targetFrameRate = 60;
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
