using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
public class Testing : Agent
{
    Rigidbody rb;
    public float force = 3;
    public Transform target;
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.up);
        sensor.AddObservation(transform.forward);
        sensor.AddObservation(rb.velocity);
        sensor.AddObservation(rb.angularVelocity);
        sensor.AddObservation(transform.position);
        sensor.AddObservation(target.position);
    }
    public void Init()
    {
    }
    public override void OnEpisodeBegin()
    {
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        int i = 0;
        Vector3 v = actions.ContinuousActions[i++] * Vector3.forward; 
        v += actions.ContinuousActions[i++] * Vector3.right;
        rb.AddForce(v.normalized * force);
    }
        // Start is called before the first frame update
        void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
