using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character State Machine", menuName = "StateMachines/Character")]
public class InputStateMachine : ScriptableObject
{
    public InputState CurrentPlayerState { get; private set; }
    [field: SerializeField] public GameEventSO IdleEvent { get; private set; }
    [field: SerializeField] public GameEventSO MoveEvent { get; private set; }
    [field: SerializeField] public GameEventSO RunSlowEvent { get; private set; }
    [field: SerializeField] public GameEventSO RunEvent { get; private set; }
    [field: SerializeField] public GameEventSO AttackEvent { get; private set; }

    public void ChangeState(InputState NewPlayerState)
    {
        switch (NewPlayerState)
        {
            case InputState.Idle:
                IdleEvent.Raise();
                break;
            case InputState.Walk:
                MoveEvent.Raise();
                break;
            case InputState.RunSlow:
                RunSlowEvent.Raise();
                break;
            case InputState.Run:
                RunEvent.Raise();
                break;
            case InputState.Attack:
                AttackEvent.Raise();
                break;
        }
        CurrentPlayerState = NewPlayerState;
    }
}

public enum InputState
{
    Idle,
    Walk,
    RunSlow,
    Run,
    Attack
}