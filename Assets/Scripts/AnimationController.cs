using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationController : MonoBehaviour
{
    public void runAnimationStart(Animator animator)
    {
        animator.SetBool("isRunning", true);
    }

    public void runAnimationFinish(Animator animator)
    {
        animator.SetBool("isRunning", false);
    }

    public void flyAnimationStart(Animator animator)
    {
        animator.SetBool("isFlying", true);
    }

    public void flyAnimationFinish(Animator animator)
    {
        animator.SetBool("isFlying", false);
    }
    public void levelEndAnimationStart(Animator animator)
    {
        animator.SetBool("levelEnd", true);
    }


    /*#region Animations
    public void animationStart()
    {
        animator.SetBool("isRunning", true);
    }

    public void animationFinish()
    {
        if (playerControl.hit.collider.gameObject.CompareTag("Path")) // Path Movement and Animation
        {
            animator.SetBool("isRunning", false);

            playerControl.myPosition.transform.DOPath(playerControl.wayPoints, playerControl.pathTime, PathType.CatmullRom).SetSpeedBased(true).SetEase(Ease.Linear).SetLookAt(0.05f)
            .SetOptions(false, AxisConstraint.None, AxisConstraint.X)
            .OnStart(() => animator.SetBool("isFlying", true)).OnComplete(() => animator.SetBool("isFlying", false));
        }

        else if (playerControl.hit.collider.gameObject.CompareTag("FinalPoint"))   // Final Movement and Animation
        {
            playerControl.myPosition.transform.DOMove(playerControl.finalPoint.transform.position - new Vector3(0, 0, 1), playerControl.speedTime).SetSpeedBased(true).SetEase(Ease.Linear)
            .OnStart(() => animator.SetBool("isRunning", true)).OnComplete(() => animator.SetBool("isRunning", false));
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    #endregion*/

}
