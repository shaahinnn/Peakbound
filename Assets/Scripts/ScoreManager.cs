using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    CoinCollect coinCollect;
    int score = 0;
    int totalScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] TextMeshProUGUI levelNextScoreText;
    void Start()
    {
        coinCollect = FindFirstObjectByType<CoinCollect>();
        scoreText.text = score.ToString();
        gameOverScoreText.text = totalScore.ToString();
        levelNextScoreText.text = totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    public void AddScore(int additionalScore)
    {
        score += additionalScore;
        scoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
        levelNextScoreText.text = score.ToString();
    }
}
