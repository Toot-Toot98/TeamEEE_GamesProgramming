using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotation = 0f;
    private float currentCameraRotation = 0f;

    public float cameraRotationLimit = 85f;

    private Rigidbody rb;
    public Camera cam;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Gets a Movement Vector
    public void Move(Vector3 _velocity)
    {

        velocity = _velocity;

    }

    // Gets a Rotational Vector
    public void Rotate(Vector3 _rotation)
    {

        rotation = _rotation;

    }

    // Gets a Rotational Vector
    public void RotateCamera(float _cameraRotation)
    {

        cameraRotation = _cameraRotation;

    }

    // Run Every Physics Iteration
    private void FixedUpdate()
    {

        PerformMovement();
        PerformRotation();

    }

    // Perform Movement Based on Velocity Variable
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    // Perform Rotation
    void PerformRotation()
    {

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null)
        {
            currentCameraRotation -= cameraRotation;
            currentCameraRotation = Mathf.Clamp(currentCameraRotation, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotation, 0f, 0f);
        }

    }

}
