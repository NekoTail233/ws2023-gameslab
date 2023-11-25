using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    protected GameManager manager;

    public GameState(GameManager m)
    {
        manager = m;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void HandleCommand(ICommand c);
    
}

