using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;


public class InputHandler : MonoBehaviour
{

    CameraActionMap input = null;
  
    public ReactiveProperty<Vector3> moveVector = new ReactiveProperty<Vector3>(Vector3.zero);
    public ReactiveProperty<Vector2> rotateCamera = new ReactiveProperty<Vector2>(Vector2.zero);
    public ReactiveProperty<Vector2> rotateAroundPivot = new ReactiveProperty<Vector2>(Vector2.zero);

    public ReactiveProperty<bool> toggleMenu = new ReactiveProperty<bool>(false);


    GameManager gameManager;
    private void Awake()
    {

        gameManager = FindFirstObjectByType<GameManager>();
        input = new CameraActionMap();
    }


   
    
    // Start is called before the first frame update
    

    private void OnEnable()
    {
        input.Enable();

        input.CameraControll.Movement.performed += OnMovementPerformend;
        input.CameraControll.Movement.canceled += OnMovementCancelled;

        input.CameraControll.OpenMenu.performed += OnOpenMenuPerformed;
        input.CameraControll.OpenMenu.canceled += OnOpenMenuCancelled;

        input.CameraControll.RotateCamera.performed += OnRotateCameraPerformed;
        input.CameraControll.RotateCamera.canceled += OnRotateCameraCancelled;

        input.CameraControll.RotateAroundPivot.started += OnRotateAroundPivotStart;
        input.CameraControll.RotateAroundPivot.performed += OnRotateAroundPivotPerformed;
        input.CameraControll.RotateAroundPivot.canceled += OnRotateAroundPivotCancelled;

        input.CameraControll.SetPivotPoint.started += _=> gameManager.cameraController.GetMouseWorldPosition(gameManager.rotateAroundPivotCommand.pivotPoint);
    }
    
    private void OnDisable()
    {
        input.Disable();
        input.CameraControll.Movement.performed -= OnMovementPerformend;
        input.CameraControll.Movement.canceled -= OnMovementCancelled;


        input.CameraControll.OpenMenu.performed -= OnOpenMenuPerformed;
        input.CameraControll.OpenMenu.canceled -= OnOpenMenuCancelled;

        input.CameraControll.RotateCamera.performed -= OnRotateCameraPerformed;
        input.CameraControll.RotateCamera.canceled -= OnRotateCameraCancelled;

        input.CameraControll.RotateAroundPivot.performed -= OnRotateAroundPivotPerformed;
        input.CameraControll.RotateAroundPivot.canceled -= OnRotateAroundPivotCancelled;
        input.CameraControll.RotateAroundPivot.canceled -= OnRotateAroundPivotStart;
    }
    void OnRotateAroundPivotStart(InputAction.CallbackContext value)
    {
        //gameManager.cameraController.GetMouseWorldPosition(gameManager.rotateAroundPivotCommand.pivotPoint);
        Debug.Log("mouse started");
    }

    void OnRotateAroundPivotPerformed(InputAction.CallbackContext value)
    {
        rotateAroundPivot.Value = value.ReadValue<Vector2>();
    }
    void OnRotateAroundPivotCancelled(InputAction.CallbackContext value)
    {
        rotateAroundPivot.Value = Vector2.zero;
    }


    void OnRotateCameraPerformed(InputAction.CallbackContext value)
    {
        rotateCamera.Value = value.ReadValue<Vector2>();
    }
    void OnRotateCameraCancelled(InputAction.CallbackContext value)
    {
        rotateCamera.Value = Vector2.zero;
    }

    void OnOpenMenuPerformed(InputAction.CallbackContext value)
    {
        toggleMenu.Value = value.ReadValue<bool>();
    }
    void OnOpenMenuCancelled(InputAction.CallbackContext value)
    {
        toggleMenu.Value = value.ReadValue<bool>();
    }
    void OnMovementPerformend(InputAction.CallbackContext value)
    {
        moveVector.Value = value.ReadValue<Vector3>();

    }

    void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector.Value = Vector3.zero;
    }
}
