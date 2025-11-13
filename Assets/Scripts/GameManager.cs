using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI instructionsText;
    
    [Header("Game Stats")]
    public int score = 0;
    public int collectiblesCollected = 0;
    public int targetsHit = 0;
    
    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        UpdateScoreUI();
    }
    
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
        Debug.Log($"Score: {score}");
    }
    
    public void CollectiblePicked()
    {
        collectiblesCollected++;
        AddScore(10);
    }
    
    public void TargetHit()
    {
        targetsHit++;
        AddScore(25);
    }
    
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}\nCollectibles: {collectiblesCollected}\nTargets Hit: {targetsHit}";
        }
    }
    
    void Update()
    {
        // Reset game with R key
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }
    
    void ResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}