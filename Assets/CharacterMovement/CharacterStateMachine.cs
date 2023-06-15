using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character State Machine", menuName = "StateMachines/Character")]
public class CharacterStateMachine : ScriptableObject
{
    public CharacterState CurrentPlayerState { get; private set; }
    [field: SerializeField] public GameEventSO IdleEvent { get; private set; }
    [field: SerializeField] public GameEventSO WalkEvent { get; private set; }
    [field: SerializeField] public GameEventSO RunSlowEvent { get; private set; }
    [field: SerializeField] public GameEventSO RunEvent { get; private set; }
    [field: SerializeField] public GameEventSO AttackEvent { get; private set; }

    public void ChangeState(CharacterState NewPlayerState)
    {
        switch (NewPlayerState)
        {
            case CharacterState.Idle:
                IdleEvent.Raise();
                break;
            case CharacterState.Walk:
                WalkEvent.Raise();
                break;
            case CharacterState.RunSlow:
                RunSlowEvent.Raise();
                break;
            case CharacterState.Run:
                RunEvent.Raise();
                break;
            case CharacterState.Attack:
                AttackEvent.Raise();
                break;
        }
        CurrentPlayerState = NewPlayerState;
    }
}

public enum CharacterState
{
    Idle,
    Walk,
    RunSlow,
    Run,
    Attack
}