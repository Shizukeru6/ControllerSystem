using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [field:SerializeField] public Animator CharacterAnimator { get; private set; }
    [field: SerializeField] public GameActionToggleAnimation ToggleRunSlow { get; private set; }

    private void OnEnable()
    {
        ToggleRunSlow.SetAnimationBool += ToggleRunSlow_SetAnimationBool;
    }

    private void OnDisable()
    {
        ToggleRunSlow.SetAnimationBool -= ToggleRunSlow_SetAnimationBool;
    }

    private void ToggleRunSlow_SetAnimationBool(bool obj)
    {
        CharacterAnimator.SetBool("RunSlow", obj);
    }

    public void Idle()
    {
        CharacterAnimator.SetTrigger("Idle");
    }

    public void Walk()
    {
        CharacterAnimator.SetTrigger("Walk");
    }

    public void RunSlow()
    {
        CharacterAnimator.SetTrigger("RunSlow");
        CharacterAnimator.SetLayerWeight(CharacterAnimator.GetLayerIndex("Run"), 1);
    }

    public void SwitchLayer()
    {

    }
}