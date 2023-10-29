using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateManager : Singleton <StateManager>
{

    int _kill;

    public int getKill() 
    {
        return _kill;

    }

    public void setKill(int newKill)
    {
        _kill = newKill;

    }
}
