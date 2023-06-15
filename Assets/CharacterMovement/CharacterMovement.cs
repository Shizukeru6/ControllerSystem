using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [field:SerializeField] public Animator CharacterAnimator { get; private set; }
    [field:SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public FloatSO MovementInputX { get; private set; }
    [field: SerializeField] public FloatSO MovementInputY { get; private set; }
    [field: SerializeField] public GameObject Character { get; private set; }

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
    }

    private void Update()
    {
        Vector3 MovementVector = MovementInputX.FloatVariable * Vector3.right + MovementInputY.FloatVariable * Vector3.forward;
        MovementVector.Normalize();

        Character.transform.Translate(MovementVector * MovementSpeed * Time.deltaTime, Space.World);
    }
}
