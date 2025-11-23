using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public int targetScore = 1000;

    public TextMeshProUGUI scoreText;
    public GameObject winText;
    private void Awake()
    {
        score = 0;
    }
    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();

        if (score >= targetScore)
        {
            Debug.Log("you won");
            
            // Show WIN UI if assigned
            if (winText != null)
                winText.SetActive(true);
            
            Time.timeScale = 0f;
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}