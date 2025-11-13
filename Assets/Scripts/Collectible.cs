using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Effects")]
    public ParticleSystem collectParticles;
    public float rotationSpeed = 100f;
    
    private bool collected = false;
    
    void Start()
    {
        // Get particle system from children
        if (collectParticles == null)
        {
            collectParticles = GetComponentInChildren<ParticleSystem>();
        }
    }
    
    void Update()
    {
        // Rotate collectible for visual effect
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;
            Collect();
        }
    }
    
    void Collect()
    {
        Debug.Log("Collectible picked up!");
        
        // Play burst of particles
        if (collectParticles != null)
        {
            // Detach particles so they continue after object is destroyed
            collectParticles.transform.SetParent(null);
            var emission = collectParticles.emission;
            emission.enabled = true;
            ParticleSystem.EmissionModule em = collectParticles.emission;
            em.rateOverTime = 100;
            
            Destroy(collectParticles.gameObject, 2f);
        }
        
        // Call GameManager to update collectible count and score
        if (GameManager.Instance != null)
        {
            GameManager.Instance.CollectiblePicked();
            Debug.Log("GameManager.CollectiblePicked() called!");
        }
        else
        {
            Debug.LogWarning("GameManager.Instance is null! Make sure GameManager exists in scene.");
        }
        
        // Destroy collectible
        Destroy(gameObject);
    }
}