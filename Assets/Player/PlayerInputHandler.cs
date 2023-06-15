using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [field:SerializeField] public CharacterStateMachine characterStateMachine { get; private set; }
    public bool IsSlowRun { get; private set; } = false;
    public Vector2 MovementInput { get; private set; } = Vector2.zero;
    [field: SerializeField] public FloatSO MovementInputX { get; private set; }
    [field: SerializeField] public FloatSO MovementInputY { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        Debug.Log(MovementInput);
        MovementInputX.FloatVariable = MovementInput.x;
        MovementInputY.FloatVariable = MovementInput.y;
        //WalkRunIdle();
        if(context.performed) characterStateMachine.ChangeState(CharacterState.Walk);
        if(context.canceled) characterStateMachine.ChangeState(CharacterState.Idle);
    }

    public void OnRunInput(InputAction.CallbackContext context)
    {
        //IsSlowRun = context.performed || context.started;
        if (context.performed) characterStateMachine.ChangeState(CharacterState.RunSlow);
        if (context.canceled) characterStateMachine.ChangeState(CharacterState.Walk);
        //WalkRunIdle();
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        characterStateMachine.ChangeState(CharacterState.Attack);
    }

    private void WalkRunIdle()
    {
        if (MovementInput == Vector2.zero) characterStateMachine.ChangeState(CharacterState.Idle);
        if (!IsSlowRun && MovementInput != Vector2.zero) characterStateMachine.ChangeState(CharacterState.Walk);
        if (IsSlowRun && MovementInput != Vector2.zero) characterStateMachine.ChangeState(CharacterState.RunSlow);
    }
}
