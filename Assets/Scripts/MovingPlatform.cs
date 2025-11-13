using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 2f;
    public bool moveToEnd = true;
    
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(10, 0, 0); // Move 10 units right
    }
    
    void FixedUpdate()
    {
        // Move platform
        if (moveToEnd)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, endPosition, speed * Time.fixedDeltaTime));
            
            if (Vector3.Distance(transform.position, endPosition) < 0.1f)
            {
                moveToEnd = false;
            }
        }
        else
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, startPosition, speed * Time.fixedDeltaTime));
            
            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                moveToEnd = true;
            }
        }
    }
}