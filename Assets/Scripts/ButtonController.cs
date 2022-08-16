using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // PlayerPrefs.SetInt("GoToScene", SceneManager.GetActiveScene().buildIndex);
    }
}
