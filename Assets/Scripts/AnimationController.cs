using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    public void runAnimationStart()
    {
        animator.SetBool("isRunning", true);
    }

    public void runAnimationFinish()
    {
        animator.SetBool("isRunning", false);
    }

    public void flyAnimationStart()
    {
        animator.SetBool("isFlying", true);
    }

    public void flyAnimationFinish()
    {
        animator.SetBool("isFlying", false);
    }
}
