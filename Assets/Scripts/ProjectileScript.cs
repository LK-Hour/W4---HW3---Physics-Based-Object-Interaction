using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Projectile hit: " + collision.gameObject.name + " (Tag: " + collision.gameObject.tag + ")");
        
        // If hit target, apply force to knock it down
        try
        {
            if (collision.gameObject.CompareTag("Target"))
            {
                Debug.Log("Target confirmed! Applying force...");
                
                Rigidbody targetRb = collision.gameObject.GetComponent<Rigidbody>();
                if (targetRb != null)
                {
                    Vector3 forceDirection = collision.contacts[0].normal * -1;
                    targetRb.AddForce(forceDirection * 500f);
                    Debug.Log("Force applied to target!");
                }
                else
                {
                    Debug.LogWarning("Target has no Rigidbody component!");
                }
                
                // Call GameManager to update score
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.TargetHit();
                    Debug.Log("GameManager.TargetHit() called!");
                }
                else
                {
                    Debug.LogWarning("GameManager.Instance is null!");
                }
            }
            else
            {
                Debug.Log("Hit object is not tagged as 'Target'");
            }
        }
        catch (UnityException e)
        {
            Debug.LogError("Tag 'Target' does not exist! Please create it. Error: " + e.Message);
        }
        
        // Destroy projectile on impact
        Destroy(gameObject);
    }
}