using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [field:SerializeField] public CharacterStateMachine characterStateMachine { get; private set; }
    [field:SerializeField] public GameActionToggleAnimation ToggleRunSlow { get; private set; }
    public bool IsSlowRun { get; private set; } = false;
    public Vector2 MovementInput { get; private set; } = Vector2.zero;

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        /*if (MovementInput == Vector2.zero) characterStateMachine.ChangeState(CharacterState.Idle);
        WalkRunIdle();*/
        if(context.performed) characterStateMachine.ChangeState(CharacterState.Walk);
        if(context.canceled) characterStateMachine.ChangeState(CharacterState.Idle);
    }

    public void OnRunInput(InputAction.CallbackContext context)
    {
        if(context.performed || context.canceled) ToggleRunSlow.InvokeAction(context.performed);
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        characterStateMachine.ChangeState(CharacterState.Attack);
    }

    private void WalkRunIdle()
    {
        if (!IsSlowRun && MovementInput != Vector2.zero) characterStateMachine.ChangeState(CharacterState.Walk);
        if (IsSlowRun && MovementInput != Vector2.zero) characterStateMachine.ChangeState(CharacterState.RunSlow);
    }
}
