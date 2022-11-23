using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasSettings : MonoBehaviour
{
    public TextMeshProUGUI dashCount,remainingCount;
    int dashListCount,remainingStepCount;
    PlayerControl playercontrol;

    private void Start()
    {
        playercontrol = GetComponent<PlayerControl>();
    }

    private void Update()
    {
        dashListCount = playercontrol.dashList.Count;
        remainingStepCount = playercontrol.remainingStep;
        dashCount.text = dashListCount.ToString();
        remainingCount.text = remainingStepCount.ToString("Remaining Step : " + "0");
    }
}
