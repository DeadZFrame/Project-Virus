using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    public float motorForce;
    public float breakForce;
    public float maxSteerAngle;
    public float topSpeed;

    private bool onTopSpeed, applyFriction;
    private float friction = 250, currentFriction;
    private float topSpeedBreak = 5000, currentTopSpeedBreak;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private Vector3 prevPos = new Vector3();
    [System.NonSerialized] public float speedval = 0;
    public static float referanced_speed_val;

    private void Awake()
    {
        referanced_speed_val = speedval;
    }
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        //if (!Input.anyKey)
        //{
        //    currentbreakForce = breakForce;
        //    ApplyBreaking();
        //}
        SpeedCalculation();
    }

    public void SpeedCalculation()
    {
        var posNow = transform.position;
        var speed = (posNow - prevPos) / Time.fixedDeltaTime;
        prevPos = posNow;

        speedval = speed.magnitude;
        referanced_speed_val = speedval;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;

        if (!Input.anyKey)
        {
            applyFriction = true;
        }
        else applyFriction = false;

        if (speedval > topSpeed)
        {
            onTopSpeed = true;
        }
        else onTopSpeed = false;

        currentFriction = applyFriction ? friction : 0f;
        currentTopSpeedBreak = onTopSpeed ? topSpeedBreak : 0f;

        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;

        rearLeftWheelCollider.brakeTorque = currentTopSpeedBreak;
        rearRightWheelCollider.brakeTorque = currentTopSpeedBreak;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
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