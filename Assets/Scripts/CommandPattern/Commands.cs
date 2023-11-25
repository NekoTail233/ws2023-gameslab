// Move Command
using UnityEngine;


public class EscapeCommand : ICommand
{
    
    public void Execute()
    {
        
    }
  
}

public class MoveCommand : ICommand
{
    public Vector3 direction;
    public Transform playerTransform;


    public MoveCommand setCommand(Transform transform, Vector3 direction)
    {
        this.playerTransform = transform;
        this.direction = direction;
        return this;
    }

    
    public MoveCommand(Transform transform, Vector3 direction)
    {
        setCommand(transform, direction);
    }
    public MoveCommand(MoveCommand commandToCopy)
    {
        if (commandToCopy != null)
        {
            this.playerTransform = commandToCopy.playerTransform;
            this.direction = commandToCopy.direction;
        }
    }
    public MoveCommand()
    {
       
    }

    public void Execute()
    {
        //playerTransform.Translate(direction);
    }

    public ICommand setC()
    {
        return this;
    }
}

// Click Command
public class ClickCommand : ICommand
{
    public void Execute()
    {
        Debug.Log("Click action executed");
        // Implement click logic here
    }

    public void setC()
    {
        throw new System.NotImplementedException();
    }
}

public class RotateCameraCommand : ICommand
{
    public Vector2 rotate;
    public RotateCameraCommand (RotateCameraCommand commandToCopy)
    {
        if (commandToCopy != null)
        {
            this.rotate = commandToCopy.rotate;
        }
    }

    public RotateCameraCommand()
    {

    }


    public void Execute()
    {
        
    }
    public RotateCameraCommand setC(Vector2 rotate)
    {
        this.rotate = rotate;
        return this;
    }
}

public class RotateAroundPivotCommand : ICommand
{
    public Transform pivotPoint;
    public Vector3 rotationAxis = Vector3.up;
    public Vector2 rotationAmount;

    public RotateAroundPivotCommand(RotateAroundPivotCommand commandToCopy)
    {
        if (commandToCopy != null)
        {
            this.pivotPoint = commandToCopy.pivotPoint;
            this.rotationAxis = commandToCopy.rotationAxis;
            this.rotationAmount = commandToCopy.rotationAmount;
        }
    }

    public RotateAroundPivotCommand()
    {

    }

    public void Execute()
    {
        // Implementation for executing the rotation around pivot command
    }

    public RotateAroundPivotCommand SetCommand(Transform pivotPoint, Vector3 rotationAxis, Vector2 rotationAmount)
    {
        this.pivotPoint = pivotPoint;
        this.rotationAxis = rotationAxis;
        this.rotationAmount = rotationAmount;
        return this;
    }
    public RotateAroundPivotCommand SetCommand(Vector3 rotationAxis, Vector2 rotationAmount)
    {
        
        this.rotationAxis = rotationAxis;
        this.rotationAmount = rotationAmount;
        return this;
    }
}
