using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player State Machine", menuName = "StateMachines/Player")]
public class PlayerStateMachine : ScriptableObject
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