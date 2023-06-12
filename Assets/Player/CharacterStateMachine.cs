using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character State Machine", menuName = "StateMachines/Character")]
public class CharacterStateMachine : ScriptableObject
{
    public PlayerState CurrentPlayerState { get; private set; }
    public GameEventSO IdleEvent { get; private set; }
    public GameEventSO WalkEvent { get; private set; }
    public GameEventSO SlowRunEvent { get; private set; }
    public GameEventSO RunEvent { get; private set; }
    public GameEventSO AttackEvent { get; private set; }

    public void ChangeState(PlayerState NewPlayerState)
    {
        switch (NewPlayerState)
        {
            case PlayerState.Idle:
                IdleEvent.Raise();
                break;
            case PlayerState.Walk:
                WalkEvent.Raise();
                break;
            case PlayerState.SlowRun:
                SlowRunEvent.Raise();
                break;
            case PlayerState.Run:
                RunEvent.Raise();
                break;
            case PlayerState.Attack:
                AttackEvent.Raise();
                break;
        }
        CurrentPlayerState = NewPlayerState;
    }
}

public enum PlayerState
{
    Idle,
    Walk,
    SlowRun,
    Run,
    Attack
}