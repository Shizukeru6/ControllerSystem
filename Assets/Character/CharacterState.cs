using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    [field:SerializeField] public Animator CharacterAnimator { get; private set; }

    public void Idle()
    {
        CharacterAnimator.SetTrigger("Idle");
    }

    public void Walk()
    {
        CharacterAnimator.SetTrigger("Walk");
    }
}