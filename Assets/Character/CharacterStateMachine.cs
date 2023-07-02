using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character State Machine", menuName = "StateMachines/Character")]
public class CharacterStateMachine : ScriptableObject
{
    public CharacterStateOptions CurrentCharacterState { get; private set; }
    [field: SerializeField] public GameEventSO IdleEvent { get; private set; }
    [field: SerializeField] public GameEventSO MoveEvent { get; private set; }
    [field: SerializeField] public GameEventSO AttackEvent { get; private set; }

    public void ChangeState(CharacterStateOptions NewPlayerState)
    {
        switch (NewPlayerState)
        {
            case CharacterStateOptions.Idle:
                IdleEvent.Raise();
                break;
            case CharacterStateOptions.Move:
                MoveEvent.Raise();
                break;
            case CharacterStateOptions.Attack:
                AttackEvent.Raise();
                break;
        }
        CurrentCharacterState = NewPlayerState;
    }
}

public enum CharacterStateOptions
{
    Idle,
    Move,
    Attack
}