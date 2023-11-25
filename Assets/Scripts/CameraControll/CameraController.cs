using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;
public class CameraController : MonoBehaviour
{
    public Camera currentCamera;
    InputHandler inputHandler;
    public Transform startPosBunker;
    public Transform startPosSurface;

    public Transform lastPosBunker;
    public Transform lastPosSurface;
    public GameManager gameManager;
    public CameraFollow cameraFollow;
    void copyTransform(Transform to, Transform from)
    {
        to.position = from.position;
        to.rotation = from.rotation;
    }
    public void StartBunker()
    {
        copyTransform(lastPosBunker, startPosBunker);
        copyTransform(transform, startPosBunker);
    }
    public void StartSurface()
    {
        copyTransform(transform, startPosSurface);
    }
    public void GetMouseWorldPosition(Transform pivot)
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
        
          pivot.position =  hit.point;
          transform.LookAt(pivot);// This is the 3D point in the world
        }
       
         // Return null if nothing is hit
    }

    public void RotateAroundPivotBunker(RotateAroundPivotCommand c)
    {
        if(c.rotationAmount != Vector2.zero)
        {
            Vector3 offset = c.pivotPoint.position - transform.position;
            Vector3 r = Vector3.Cross(offset, Vector3.up);

            float pivot = gameManager.globalStats.pivotFactor;
            transform.RotateAround(c.pivotPoint.position, Vector3.up, pivot *c.rotationAmount.x * gameManager.globalStats.bunkerRotateSpeed * Time.deltaTime);
            transform.RotateAround(c.pivotPoint.position, r, pivot * c.rotationAmount.y * gameManager.globalStats.bunkerRotateSpeed * Time.deltaTime);

            transform.LookAt(c.pivotPoint);
        }
   

    }

    public void RotateBunker(RotateCameraCommand c)
    {
        float rot = c.rotate.y;
        float speed = gameManager.globalStats.bunkerRotateSpeed;
        rot *= speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, rot, 0) * transform.rotation;
    }
    public void MoveBunker(MoveCommand c)
    {

        float speed = gameManager.globalStats.bunkerCameraMovementSpeed;
        copyTransform(lastPosBunker, transform);
        Vector3 dir = c.direction;
        if(dir == Vector3.zero)
        {
            return;
        }
        dir = dir.normalized;
        Vector3 f = transform.forward ;
        Vector3 r = transform.right ;
        Vector3 u = Vector3.up;

        f.y = 0;
        r.y = 0;
        Vector3 move = f.normalized * dir.y + r.normalized * dir.x + u * dir.z;
        Debug.Log("transform by" + move);
        transform.position += (move * speed * Time.deltaTime);
        
    }
    // Start is called before the first frame update
    void Start()
    {

        lastPosBunker = new GameObject().transform;
        lastPosSurface = new GameObject().transform;

        currentCamera = Camera.main;
        gameManager = FindFirstObjectByType<GameManager>();
        cameraFollow = FindFirstObjectByType<CameraFollow>();
        cameraFollow.target = transform;
        
    }




    // Update is called once per frame
   
}
