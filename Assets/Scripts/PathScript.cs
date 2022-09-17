using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public void pathDraw(Transform myPosition, Vector3[] wayPoints,float pathTime, Animator animator,AnimationController animationC)
    {
        myPosition.transform.DOPath(wayPoints, pathTime, PathType.Linear).SetSpeedBased(true).SetEase(Ease.Linear).SetLookAt(0.05f)
        .SetOptions(false, AxisConstraint.None, AxisConstraint.X)
        .OnStart(() => animationC.flyAnimationStart(animator)).OnComplete(() => animationC.flyAnimationFinish(animator));
    }
}
