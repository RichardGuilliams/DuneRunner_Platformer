using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    [Header("Animator")]
    public Animator animator;
    #region Animation States

    public void ResetAnimationStates()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
        animator.SetBool("isClimbing", false);
        animator.SetBool("isExhausted", false);
        animator.SetBool("isHurt", false);
        animator.SetBool("isStanding", false);
    }

    public void SetAnimationState(string name, bool on)
    {
        switch (name)
        {
            case "Walking":
                animator.SetBool("isWalking", on);
                break;
            case "running":
                animator.SetBool("isRunning", on);
                break;
            case "jumping":
                animator.SetBool("isJumping", on);
                break;
            case "climbing":
                animator.SetBool("isClimbing", on);
                break;
            case "falling":
                animator.SetBool("isFalling", on);
                break;
            case "hurt":
                animator.SetBool("isHurt", on);
                break;
            case "exhausted":
                animator.SetBool("isExhausted", on);
                break;
            case "standing":
                animator.SetBool("isStanding", on);
                break;
        }
    }
    #endregion
}
