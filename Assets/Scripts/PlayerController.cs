using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 10f;
    public float maxSpeed = 5f; // Reduced for capsule
    public float jumpForce = 5f;
    public float rotationSpeed = 10f; // NEW: rotation speed
    
    [Header("Physics Properties")]
    public float mass = 1f;
    public float drag = 2f; // Increased for capsule
    public float angularDrag = 5f; // Increased for capsule
    
    [Header("Ground Check")]
    public float groundCheckDistance = 1.1f; // Adjusted for capsule height
    public LayerMask groundLayer;
    
    private Rigidbody rb;
    private bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Apply customizable physics properties
        rb.mass = mass;
        rb.drag = drag;
        rb.angularDrag = angularDrag;
        
        // IMPORTANT: Freeze rotation on X and Z to prevent rolling
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    
    void Update()
    {
        // Check if grounded
        CheckGround();
        
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    
    void FixedUpdate()
    {
        // Get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Calculate movement direction relative to camera
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        
        // Flatten camera directions to horizontal plane
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();
        
        // Calculate movement direction based on camera orientation
        Vector3 movement = (cameraForward * vertical + cameraRight * horizontal).normalized;
        
        // Apply force (REQUIREMENT: AddForce)
        rb.AddForce(movement * moveForce);
        
        // Limit max speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        
        // NO rotation - player stays facing forward, only camera rotates
    }
    
    void Jump()
    {
        // Apply upward force using Impulse mode
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("Jump!");
    }
    
    void CheckGround()
    {
        // Raycast downward to check for ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance))
        {
            isGrounded = hit.collider.CompareTag("Ground") || 
                        hit.collider.CompareTag("Platform");
            
            // Debug visualization
            Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.green);
        }
        else
        {
            isGrounded = false;
            Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.red);
        }
    }
    
    // Collision Detection (REQUIREMENT)
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player collided with: " + collision.gameObject.name);
        
        // Special collision responses
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Hit a target!");
        }
    }
    
    // Trigger Detection (REQUIREMENT)
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player triggered: " + other.gameObject.name);
        
        // Safely check for Collectible tag
        try
        {
            if (other.CompareTag("Collectible"))
            {
                Debug.Log("Collected item!");
            }
        }
        catch (UnityException)
        {
            // Tag doesn't exist yet - no problem
        }
    }
    
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Player stopped touching: " + collision.gameObject.name);
    }
}