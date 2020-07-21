using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public void GetInput() 
    {
        mHorizontalInput = Input.GetAxis("Horizontal");
        mVerticalInput = Input.GetAxis("Vertical");
    }

    public void Steer()
    {
        mSteeringAngle = maxSteerAngle * mHorizontalInput;
        frontDriverWheel.steerAngle = mSteeringAngle;
        frontPassangerWheel.steerAngle = mSteeringAngle;
    }

    public void Accelerate()
    {
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            frontDriverWheel.motorTorque = mVerticalInput * (motorForce / 2);
            frontPassangerWheel.motorTorque = mVerticalInput * (motorForce / 2);

            Debug.Log("mamasita linda");
        }

        if(Input.GetKey("space")){
            frontDriverWheel.motorTorque = 0;
            frontPassangerWheel.motorTorque = 0;
        }

        else {
            frontDriverWheel.motorTorque = mVerticalInput * motorForce;
            frontPassangerWheel.motorTorque = mVerticalInput * motorForce;
        }
    }

    public void UpdateWheelPoses()
    {
        UpdateWheelPose(frontPassangerWheel, frontPassangerTransform);
        UpdateWheelPose(frontDriverWheel, frontDriverTransform);
        UpdateWheelPose(backPassangerWheel, backPassangerTransform);
        UpdateWheelPose(backDriverWheel, backDriverTransform);
    }

    private void UpdateWheelPose(WheelCollider collider, Transform transform) 
    {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;

        collider.GetWorldPose(out pos, out quat);
        
        transform.position = pos;
        transform.rotation = quat;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
            
    }

    private float mHorizontalInput;
    private float mVerticalInput;
    private float mSteeringAngle;

    public WheelCollider frontDriverWheel, frontPassangerWheel;
    public WheelCollider backDriverWheel, backPassangerWheel;

    public Transform frontDriverTransform, frontPassangerTransform;
    public Transform backDriverTransform, backPassangerTransform;

    public float maxSteerAngle = 30;
    public float motorForce = 50;


}
