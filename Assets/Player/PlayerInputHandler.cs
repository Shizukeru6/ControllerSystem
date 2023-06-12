using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public CharacterStateMachine characterStateMachine { get; private set; }
    public void OnMoveInput(InputAction.CallbackContext context)
    {

    }

    public void OnRunInput(InputAction.CallbackContext context)
    {
        characterStateMachine.ChangeState(PlayerState.Run);
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        characterStateMachine.ChangeState(PlayerState.Attack);
    }
}
