using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;

    private MyPID pidX;
    private MyPID pidY;
    private MyPID pidZ;
    public Vector3 pV;
    public Vector3 iV;
    public Vector3 dV;

    private Vector3 velocity = Vector3.zero;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Initialize MyPID controllers for each axis
        pidX = gameObject.AddComponent<MyPID>();
        pidX.init(pV.x, iV.x, dV.x);
        pidY = gameObject.AddComponent<MyPID>();
        pidY.init(pV.y, iV.y, dV.y);
        pidZ = gameObject.AddComponent<MyPID>();
        pidZ.init(pV.z, iV.z, dV.z);
    }
    void UpdatePIDFactors()
    {
        pidX.SetFactors(new Vector3(pV.x, iV.x, dV.x));
        pidY.SetFactors(new Vector3(pV.y, iV.y, dV.y));
        pidZ.SetFactors(new Vector3(pV.z, iV.z, dV.z));
    }
    void FixedUpdate()
    {
        UpdatePIDFactors();
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            Vector3 currentPosition = transform.position;

            // Calculate error for each axis
            float errorX = targetPosition.x - currentPosition.x;
            float errorY = targetPosition.y - currentPosition.y;
            float errorZ = targetPosition.z - currentPosition.z;

            // Update MyPID for each axis
            float forceX = Mathf.Clamp(pidX.update(errorX, Time.deltaTime),-100,100);
            float forceY = Mathf.Clamp(pidY.update(errorY, Time.deltaTime), -100, 100);
            float forceZ = Mathf.Clamp(pidZ.update(errorZ, Time.deltaTime), -100, 100);

            Vector3 f = new Vector3(forceX, forceY, forceZ);
            rb.AddForce(f);
            // Apply forces to velocity
            velocity.x += forceX;
            velocity.y += forceY;
            velocity.z += forceZ;

            // Update position
            //transform.position += velocity * Time.deltaTime;
        }
    }
}
