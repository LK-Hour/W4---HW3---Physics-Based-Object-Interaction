using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 20f;
    public float shootCooldown = 0.5f;
    
    [Header("Raycasting Settings")]
    public float rayDistance = 100f;
    public LayerMask targetLayer;
    
    private float lastShootTime;
    
    void Update()
    {
        // Rotate shoot point to match camera direction for accurate aiming
        if (Camera.main != null)
        {
            shootPoint.rotation = Quaternion.Euler(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 0);
        }
        
        // Raycast for aiming (visualization only)
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, rayDistance))
        {
            // Draw ray in Scene view
            Debug.DrawRay(shootPoint.position, shootPoint.forward * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(shootPoint.position, shootPoint.forward * rayDistance, Color.green);
        }
        
        // Shoot on LEFT CLICK (Mouse Button 0) - only when cursor is locked
        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.Locked && Time.time > lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }
    
    void Shoot()
    {
        // Spawn projectile
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        
        // Ignore collision with player who shot it
        Collider projectileCollider = projectile.GetComponent<Collider>();
        Collider playerCollider = GetComponent<Collider>();
        if (projectileCollider != null && playerCollider != null)
        {
            Physics.IgnoreCollision(projectileCollider, playerCollider);
        }
        
        // Apply force
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        }
        
        // Destroy after 5 seconds
        Destroy(projectile, 5f);
        
        Debug.Log("Shot fired!");
    }
}