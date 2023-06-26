using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLayer : MonoBehaviour
{
    [field: SerializeField] public Animator Layer { get; private set; }
    public GameActionSetLayer gameActionSetLayer;


    private void OnEnable()
    {
        gameActionSetLayer = new GameActionSetLayer(gameActionSetLayer);
        gameActionSetLayer.SetLayer += GameActionSetLayer_SetLayer;
        /*GameActionSetLayer gameActionSetLayer = new GameActionSetLayer();
        gameActionSetLayer.SetLayer += GameActionSetLayer_SetLayer;*/
    }

    private void OnDisable()
    {
        gameActionSetLayer.SetLayer -= GameActionSetLayer_SetLayer;
    }

    private void GameActionSetLayer_SetLayer(string arg1, float arg2)
    {
        Debug.Log(arg1);
    }
}
