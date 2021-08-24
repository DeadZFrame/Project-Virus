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

    public GameObject FrontWheel, RearWheel, handleBar;

    private void FixedUpdate()
    {
        GetInput();
        Motor();
        HandleSteering();
    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxis(horizontal);
        verticalInput = -Input.GetAxis(vertical);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    public void Motor()
    {
        FrontWheel.GetComponent<WheelCollider>().motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    public void ApplyBreaking()
    {
        FrontWheel.GetComponent<WheelCollider>().brakeTorque = currentbreakForce;
        RearWheel.GetComponent<WheelCollider>().brakeTorque = currentbreakForce;
    }

    public void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        FrontWheel.GetComponent<WheelCollider>().steerAngle = currentSteerAngle;
    }

    public void UpdateWheels()
    {
        UpdateSingleWheel(FrontWheel.GetComponent<WheelCollider>(), FrontWheel.transform);
        UpdateSingleWheel(RearWheel.GetComponent<WheelCollider>(), RearWheel.transform);
        handleBar.transform.rotation = FrontWheel.transform.rotation;
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
