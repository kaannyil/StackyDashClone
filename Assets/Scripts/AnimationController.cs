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
}
