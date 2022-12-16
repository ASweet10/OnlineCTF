using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Movement Controls")]
    [SerializeField] private KeyCode accelerateKey = KeyCode.W;
    [SerializeField] private KeyCode reverseKey = KeyCode.S;
    [SerializeField] private KeyCode turnLeftKey = KeyCode.A;
    [SerializeField] private KeyCode turnRightKey = KeyCode.D;
    [SerializeField] private KeyCode brakeKey = KeyCode.Space;


    [Header("Wheels")]
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [SerializeField] private float maxAcceleration = 1000f;
    [SerializeField] private float motorForce = 600f;
    [SerializeField] private float brakeForce = 3000f;
    [SerializeField] private float maxSteerAngle = 30f;


    [SerializeField] private Rigidbody rb;

    private float verticalInput;
    private float horizontalInput;
    private float currentBrakeForce;
    private float currentSteerAngle;

    private bool canMove = true;
    private bool isBraking;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.9f, 0);
    }

    private void Update()
    {
        if(canMove)
        {
            GetMovementInput();
            UpdateWheelVisuals();
        }
    }

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
    }

    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBraking = Input.GetKey(brakeKey); 
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce * maxAcceleration * Time.deltaTime;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce * maxAcceleration * Time.deltaTime;

        if(isBraking) {
            currentBrakeForce = brakeForce;
        } else {
            currentBrakeForce = 0f;
        }

        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        frontRightWheelCollider.brakeTorque = currentBrakeForce;
        rearLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
    }
    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void HandleBraking()
    {
        
    }

    private void UpdateWheelVisuals()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;

        wheelCollider.GetWorldPose(out position, out rotation);

        wheelTransform.rotation = rotation;
        wheelTransform.position = position;
    }

    public void ToggleCarMovement(bool letMeMove)
    {
        if(letMeMove) {
            canMove = true;
        } else {
            canMove = false;
        }
    }
}
