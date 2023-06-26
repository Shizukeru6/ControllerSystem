using System;
using System.Collections;
using System.Collections.Generic;

public class GameActionSetLayer
{
    public event Action<string, float> SetLayer;
    public static GameActionSetLayer ActionSetLayer;

    public GameActionSetLayer()
    {

    }

    public GameActionSetLayer(GameActionSetLayer Clone)
    {
        SetLayer = Clone.SetLayer; 
    }

    public void Invoke(string LayerName, float Weight)
    {
        SetLayer?.Invoke(LayerName, Weight);
    }

    public void Listen()
    {
        
    }
}
