using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string horizontal = "horizontal";
    private const string vertical = "vertical";

    private float horizontaInput;
    private float verticalInput;
    private float currentBreakAngle;
    private float currentSteerAngle;
    private bool isBreaking = false;

    [SerializeField] private float motorForce, breakForce, maxSteerAnge;

    public Transform frontLeftWheelTransform;
    public Transform frontRightWheeTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public WheelCollider frontLeftWheel, frontRightWheel, rearLeftWheel, rearRightWheel;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    public void GetInput()
    {
        horizontaInput = Input.GetAxis(horizontal);
        verticalInput = Input.GetAxis(vertical);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    public void HandleMotor()
    {
        frontLeftWheel.motorTorque = verticalInput * motorForce;
        frontRightWheel.motorTorque = verticalInput * motorForce;
        currentBreakAngle = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    public void ApplyBreaking()
    {
        frontLeftWheel.brakeTorque = currentBreakAngle;
        frontRightWheel.brakeTorque = currentBreakAngle;
        rearLeftWheel.brakeTorque = currentBreakAngle;
        rearRightWheel.brakeTorque = currentBreakAngle;
    }

    public void HandleSteering()
    {
        currentSteerAngle = maxSteerAnge * horizontaInput;
        frontLeftWheel.steerAngle = currentSteerAngle;
        frontRightWheel.steerAngle = currentSteerAngle;
    }

    public void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheel, frontLeftWheelTransform);
        UpdateSingleWheel(frontLeftWheel, frontRightWheeTransform);
        UpdateSingleWheel(frontLeftWheel, rearRightWheelTransform);
        UpdateSingleWheel(frontLeftWheel, rearLeftWheelTransform);


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
