using UnityEngine;
using TMPro;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] int scoreToAdd = 10;
    AudioManager audioManager;
    int layerIndex;
    bool isCollected = true;
    ScoreManager scoreManager;
    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Player");
        scoreManager = FindFirstObjectByType<ScoreManager>();
        audioManager = AudioManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layerIndex && isCollected == true)
        {
            Destroy(gameObject);
            scoreManager.AddScore(scoreToAdd);
            audioManager.PlayCoinAudio();
        }
    }
    public void StopCollecting()
    {
        isCollected = false;
    }
}
