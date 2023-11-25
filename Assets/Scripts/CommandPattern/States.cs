using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Menu State

//for main menu, lostgame, leave game
public class LeaveGameState : GameState
{
    
    public LeaveGameState(GameManager m) : base(m)
    {
        
    }
    public override void EnterState()
    {
        //do clean up and call switchscene to mainmenu
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void HandleCommand(ICommand c)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}
public class BunkerPlayingState : GameState
{

    public BunkerPlayingState(GameManager m) : base(m)
    {

    }
    public override void EnterState()
    {
        //sound play
        Debug.Log("Bunker PLaying state");
        
    }

    public override void ExitState()
    {
       
    }

    public override void HandleCommand(ICommand c)
    {
        if(c is MoveCommand)
        {
            var mc = (MoveCommand)c;
            moveC = new MoveCommand(mc);
            return;
        }
        if(c is RotateCameraCommand)
        {
            var rc = (RotateCameraCommand)c;
            rotateC = new RotateCameraCommand(rc);
            return;
        }
        if(c is RotateAroundPivotCommand)
        {
            var rc = (RotateAroundPivotCommand)c;
            rapC = new RotateAroundPivotCommand(rc);
            return;
        }
    }
    MoveCommand moveC;
    RotateCameraCommand rotateC;
    RotateAroundPivotCommand rapC;
    public override void UpdateState()
    {
        if(moveC!= null)
        {
            manager.cameraController.MoveBunker(moveC);
        }
        if(rotateC != null)
        {
            manager.cameraController.RotateBunker(rotateC);
        }

        if(rapC != null)
        manager.cameraController.RotateAroundPivotBunker(rapC);
        
    }
}
public class SurfacePlayingState : GameState
{
    public SurfacePlayingState(GameManager m) : base(m)
    {
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void HandleCommand(ICommand c)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}

public class BunkerBuildingModeState : GameState
{
    public BunkerBuildingModeState(GameManager m) : base(m)
    {
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void HandleCommand(ICommand c)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}

public class BunkerPlacingModeState : GameState
{
    public BunkerPlacingModeState(GameManager m) : base(m)
    {
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void HandleCommand(ICommand c)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}

public class SurfaceBuildingModeState : GameState
{
    public SurfaceBuildingModeState(GameManager m) : base(m)
    {
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void HandleCommand(ICommand c)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}

public class SurfacePlacingModeState : GameState
{
    public SurfacePlacingModeState(GameManager m) : base(m)
    {
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void HandleCommand(ICommand c)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}


public class PlayMenuState : GameState
{
    public PlayMenuState(GameManager m): base(m)
    {

    }
    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void HandleCommand(ICommand c)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}

public class StartState : GameState
{

    public StartState(GameManager m) : base(m)
    {

    }
    public override void EnterState()
    {
        //init stuff like fade in etc.
        //init game with everything
        manager.cameraController.StartBunker();
        manager.TransitionToState(manager.bunkerPlayingState);
    }

    public override void ExitState()
    {
       
    }

    public override void HandleCommand(ICommand c)
    {
       
    }

    public override void UpdateState()
    {
        
    }
}


// Gameplay State


// Additional states like PauseState, GameOverState, etc.
