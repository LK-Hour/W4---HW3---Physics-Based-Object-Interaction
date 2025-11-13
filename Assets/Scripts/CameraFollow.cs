using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;
    
    [Header("Camera Position")]
    public Vector3 offset = new Vector3(0, 2, -5); // Lower and closer for better shooting angle
    public float smoothSpeed = 10f;
    
    [Header("Camera Rotation")]
    public float mouseSensitivity = 3f;
    public float minVerticalAngle = -60f; // Look further down for shooting downward
    public float maxVerticalAngle = 80f;  // Look further up
    
    private float currentHorizontalAngle = 0f;
    private float currentVerticalAngle = 20f;
    
    void Start()
    {
        // Lock cursor for better camera control
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // Initialize angles from camera's starting rotation
        Vector3 angles = transform.eulerAngles;
        currentHorizontalAngle = angles.y;
        currentVerticalAngle = angles.x;
    }
    
    void Update()
    {
        // Always rotate camera with mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        currentHorizontalAngle += mouseX;
        currentVerticalAngle -= mouseY;
        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, minVerticalAngle, maxVerticalAngle);
        
        // Press ESC to unlock cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        // Press TAB or E to lock cursor again (when unlocked) - NOT left click!
        if (Cursor.lockState == CursorLockMode.None && (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.E)))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    
    void LateUpdate()
    {
        if (target == null) return;
        
        // Calculate rotation
        Quaternion rotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);
        
        // Calculate position with rotation
        Vector3 rotatedOffset = rotation * offset;
        Vector3 desiredPosition = target.position + rotatedOffset;
        
        // Smooth follow
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        
        // Look at target
        transform.LookAt(target.position + Vector3.up * 1f); // Look at capsule center
    }
}