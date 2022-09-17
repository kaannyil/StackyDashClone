using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class StartCameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject CameraVCam;
    [SerializeField] private float cameraTime = 2;
    private void Start()
    {
        cameraMovement();
    }
    [Button]
    void cameraMovement()
    {
        transform.DOMove(CameraVCam.transform.position, cameraTime).SetEase(Ease.InOutSine);
    }
 }
