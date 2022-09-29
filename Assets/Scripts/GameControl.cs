using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private void Awake()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        Application.targetFrameRate = 60;
    }
}
