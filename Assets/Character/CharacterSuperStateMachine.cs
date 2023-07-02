using UnityEngine;

[CreateAssetMenu(fileName = "Character Super State Machine", menuName = "StateMachines/SuperState")]
public class CharacterSuperStateMachine : ScriptableObject
{
    public CharacterSuperStateOptions CurrentSuperState { get; private set; }
    [field: SerializeField] public GameEventSO LowEvent { get; private set; }
    [field: SerializeField] public GameEventSO MiddleEvent { get; private set; }
    [field: SerializeField] public GameEventSO HighEvent { get; private set; }

    public void ChangeState(CharacterSuperStateOptions NewPlayerState)
    {
        switch (NewPlayerState)
        {
            case CharacterSuperStateOptions.Low:
                LowEvent.Raise();
                break;
            case CharacterSuperStateOptions.Middle:
                MiddleEvent.Raise();
                break;
            case CharacterSuperStateOptions.High:
                HighEvent.Raise();
                break;
        }
        CurrentSuperState = NewPlayerState;
    }
}

public enum CharacterSuperStateOptions
{
    Low,
    Middle,
    High
}