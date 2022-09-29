using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasSettings : MonoBehaviour
{
    public TextMeshProUGUI dashCount;
    int dashListCount;
    PlayerControl playercontrol;

    private void Start()
    {
        playercontrol = GetComponent<PlayerControl>();
    }

    private void Update()
    {
        dashListCount = playercontrol.dashList.Count;
        dashCount.text = dashListCount.ToString();
    }
}
