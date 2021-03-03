using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public float lookSens = 5f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        // Calculate Movement Velocity as a 3D Vector
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;
        
        // Final Movement Vector
        Vector3 _velocity = (movHorizontal + movVertical).normalized * speed;

        //Apply Movement
        motor.Move(_velocity);

        // Calculate rotation as a 3D Vector (Turning Around)
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, yRot, 0f) * lookSens;

        // Apply Player Rotation
        motor.Rotate(_rotation);

        // Calculate Camera Rotation as a 3D Vector
        float xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotation = xRot * lookSens;

        // Apply Camera Rotation
        motor.RotateCamera(_cameraRotation);
    }
}
