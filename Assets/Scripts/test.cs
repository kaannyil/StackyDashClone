using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class test : MonoBehaviour
{
    [SerializeField] private float pathSpeed;
    [SerializeField] private Vector3[] wayPoints;

    [Button]
    private void test2()
    {
        transform.DOPath(wayPoints, pathSpeed, PathType.CatmullRom).SetEase(Ease.Linear).SetLookAt(0.05f)
        .SetOptions(false, AxisConstraint.None, AxisConstraint.X);
    }
}
