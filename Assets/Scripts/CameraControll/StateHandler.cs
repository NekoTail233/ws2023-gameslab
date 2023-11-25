using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateHandler : MonoBehaviour
{
    
    public GameState GetCurrentState()
    {
        return currentState;
    }
    protected GameState currentState;
    protected GameState previousState;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TransitionToState(GameState newState)
    {
        previousState = currentState;
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }
    public void ExecuteCommand(ICommand command)
    {
        currentState.HandleCommand(command);
    }
}
