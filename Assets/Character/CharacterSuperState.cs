using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSuperState : MonoBehaviour
{
    [field : SerializeField] public Animator animator { get; private set; }
    private string Speed;

    public void Walk()
    {
        Speed = "Walk";
        SetLayer();
    }

    public void RunSlow()
    {
        Speed = "RunSlow";
        SetLayer();
    }

    public void Run()
    {
        Speed = "Run";
        SetLayer();
    }

    private void SetLayer()
    {
        
    }
}
