using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject cam, restartBut, startButton,stackCountTM,remainingStepTM;
    PlayerControl playercontrol;
    private void Start()
    {
        playercontrol = GetComponent<PlayerControl>();
    }

    public void secondCameraDeactive()
    {
        cam.SetActive(false);
        startButton.SetActive(false);
        restartBut.SetActive(true);
        stackCountTM.SetActive(true);
        remainingStepTM.SetActive(true);
        StartCoroutine(startCanMove());
    }
    IEnumerator startCanMove()
    {
        yield return new WaitForSeconds(1.2f);
        playercontrol.canMove = true;
    }
    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // PlayerPrefs.SetInt("GoToScene", SceneManager.GetActiveScene().buildIndex);
    }
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
