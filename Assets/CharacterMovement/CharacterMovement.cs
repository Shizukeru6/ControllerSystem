using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [field:SerializeField] public Animator CharacterAnimator { get; private set; }
    [field: SerializeField] public GameActionToggleAnimation ToggleRunSlow { get; private set; }
    [field:SerializeField] public float MovementSpeed { get; private set; }

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
        MovementSpeed = 0;
        CharacterAnimator.SetTrigger("Idle");
    }

    public void Walk()
    {
        MovementSpeed = 10;
        CharacterAnimator.SetTrigger("Walk");
    }

    public void RunSlow()
    {
        MovementSpeed = 20;
        CharacterAnimator.SetTrigger("RunSlow");
        CharacterAnimator.SetLayerWeight(CharacterAnimator.GetLayerIndex("Run"), 1);
    }

    public void SwitchLayer()
    {

    }
}