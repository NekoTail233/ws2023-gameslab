using System;
using UnityEngine;
using UniRx;

/// <summary>
/// How It Works:
///The GameManager starts in a specific state, like MenuState.
///Each state manages its own behavior and can trigger transitions to other states.
///The GameManager delegates the behavior to the current state, allowing for dynamic changes based on the game's phase.
///UI or other game events can trigger state transitions through the GameManager. (ChatGPT4 text)
/// </summary>
public class GameManager : StateHandler
{

    public GlobalStats globalStats;

    public GameObject currentContextMenu;
    public GameObject lastContextMenu;

    public CameraController cameraController;
    public GameObject PlayMainMenu;



    public InputHandler inputHandler;


    public LeaveGameState leaveGameState;
    public BunkerPlayingState bunkerPlayingState;
    public SurfacePlayingState surfacePlayingState;
    public BunkerBuildingModeState bunkerBuildingModeState;
    public BunkerPlacingModeState bunkerPlacingModeState;
    public SurfaceBuildingModeState surfaceBuildingModeState;
    public SurfacePlacingModeState surfacePlacingModeState;
    public PlayMenuState playMenuState;
    public StartState startState;


    public MoveCommand MoveComend;
    public EscapeCommand ToggleMenuCommand;
    public RotateCameraCommand rotateCameraCommand;
    public RotateAroundPivotCommand rotateAroundPivotCommand;
  
    private void Awake()
    {
        leaveGameState = new LeaveGameState(this);
        bunkerPlayingState = new BunkerPlayingState(this);
        surfacePlayingState = new SurfacePlayingState(this);
        bunkerBuildingModeState = new BunkerBuildingModeState(this);
        bunkerPlacingModeState = new BunkerPlacingModeState(this);
        surfaceBuildingModeState = new SurfaceBuildingModeState(this);
        surfacePlacingModeState = new SurfacePlacingModeState(this);
        playMenuState = new PlayMenuState(this);
        startState = new StartState(this);

        MoveComend = new MoveCommand();
        ToggleMenuCommand = new EscapeCommand();
        rotateCameraCommand = new RotateCameraCommand();
        rotateAroundPivotCommand = new RotateAroundPivotCommand();
       
    }
    private void Start()
    {

        globalStats = FindFirstObjectByType<GlobalStats>();
        cameraController = FindFirstObjectByType<CameraController>();
        TransitionToState(startState);

        rotateAroundPivotCommand.pivotPoint = globalStats.pivot.transform;


        inputHandler.moveVector.Subscribe(newValue =>
        {
            ExecuteCommand(MoveComend.setCommand(transform, newValue));
        }).AddTo(inputHandler);

        inputHandler.toggleMenu.Subscribe(b =>
        { if(b != null && b==true)ExecuteCommand(ToggleMenuCommand); }
        ).AddTo(inputHandler);

        inputHandler.rotateCamera.Subscribe(r => 
        { if (r != null) ExecuteCommand(rotateCameraCommand.setC(r)); }
        ).AddTo(inputHandler);

        inputHandler.rotateAroundPivot.Subscribe(r =>
        { if (r != null) {
                
                
                ExecuteCommand(rotateAroundPivotCommand.SetCommand(Vector3.up, r)); 
            }
        }
    ).AddTo(inputHandler);
    }



}