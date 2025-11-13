using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 30f;
    public Vector3 rotationAxis = Vector3.up;
    
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        // Rotate platform using AddTorque for kinematic
        Quaternion deltaRotation = Quaternion.Euler(rotationAxis * rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}