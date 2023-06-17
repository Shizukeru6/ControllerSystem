using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Toggle Animation", menuName = "Helpers / Game Action Animation")]
public class GameActionToggleAnimation : ScriptableObject
{
    public event Action<bool> SetAnimationBool;

    public void InvokeAction(bool AnimationBool)
    {
        SetAnimationBool?.Invoke(AnimationBool);
    }
}
