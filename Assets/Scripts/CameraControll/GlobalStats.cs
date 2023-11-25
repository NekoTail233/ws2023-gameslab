using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GlobalStats : MonoBehaviour
{
    // Start is called before the first frame update
    public float bunkerCameraMovementSpeed;
    public float surfaceCameraMovementSpeed;
    public float bunkerScrollSpeed;
    public float surfaceScrollSpeed;
    public AnimationCurve scrollFactorNear;
    public float distanceFromWitchSlowScroll;
    public float bunkerRotateSpeed;
    public float surfaceRotateSpeed;
    public GameObject pivot;
    public float pivotFactor = 0.3f;
}
