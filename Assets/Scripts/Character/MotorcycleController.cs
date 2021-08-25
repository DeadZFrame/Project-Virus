using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleController : MonoBehaviour
{
    private string horizontal = "Horizontal";
    private string vertical = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    public float motorForce;
    public float breakForce;
    public float maxSteerAngle;

    public Transform FrontWheel, RearWheel, handleBar;
    public Transform frontRight, frontLeft, rearRight, rearLeft;
    public WheelCollider frontRightCollider, frontLeftCollider, rearRightCollider, rearLeftCollider, frontCollider, rearCollider;

    private Vector3 prevPos = new Vector3();
    [System.NonSerialized]public float speedval = 0;

    private void FixedUpdate()
    {
        GetInput();
        Motor();
        HandleSteering();
        UpdateWheels();
    }

    public void SpeedCalculation()
    {
        var posNow = transform.position;
        var speed = (posNow - prevPos) / Time.fixedDeltaTime;
        prevPos = posNow;

        speedval = speed.magnitude;
    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxis(horizontal);
        verticalInput = -Input.GetAxis(vertical);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    public void Motor()
    {
        frontRightCollider.motorTorque = verticalInput * motorForce;
        frontLeftCollider.motorTorque = verticalInput * motorForce;
        frontCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    public void ApplyBreaking()
    {
        frontRightCollider.brakeTorque = currentbreakForce;
        rearLeftCollider.brakeTorque = currentbreakForce;
        rearRightCollider.brakeTorque = currentbreakForce;
        frontLeftCollider.brakeTorque = currentbreakForce;
    }

    public void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontRightCollider.steerAngle = currentSteerAngle;
        frontLeftCollider.steerAngle = currentSteerAngle;
        frontCollider.steerAngle = currentSteerAngle;
    }

    public void UpdateWheels()
    {
        UpdateSingleWheel(frontRightCollider, frontRight);
        UpdateSingleWheel(rearLeftCollider, rearLeft);
        UpdateSingleWheel(rearRightCollider, rearRight);
        UpdateSingleWheel(frontLeftCollider, frontLeft);
        UpdateSingleWheel(frontCollider, FrontWheel);
        UpdateSingleWheel(rearCollider, RearWheel);    
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}