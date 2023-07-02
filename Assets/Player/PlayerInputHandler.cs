using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [field:SerializeField] public CharacterStateMachine characterStateMachine { get; private set; }
    public Vector2 MovementInput { get; private set; } = Vector2.zero;

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        /*if (MovementInput == Vector2.zero) characterStateMachine.ChangeState(CharacterState.Idle);
        WalkRunIdle();*/
        if(context.performed) characterStateMachine.ChangeState(CharacterStateOptions.Move);
        if(context.canceled) characterStateMachine.ChangeState(CharacterStateOptions.Idle);
    }

    public void OnRunInput(InputAction.CallbackContext context)
    {
        //characterStateMachine.ChangeState(CharacterState.RunSlow);
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        //characterStateMachine.ChangeState(CharacterState.Attack);
    }
}
