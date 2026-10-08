
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] CircleCollider2D playerHead;
    GameSession gameSession;
    FuelController fuelController;
    [SerializeField] GameObject gameOverPanel;
    PlayerController playerController;
    CoinCollect coinCollect;
    AudioManager audioManager;
    UIController controller;
    FinishLine finishLine;
    bool isGameOver = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
        gameSession = FindFirstObjectByType<GameSession>();
        playerController = FindFirstObjectByType<PlayerController>();
        fuelController = FindFirstObjectByType<FuelController>();
        coinCollect = FindFirstObjectByType<CoinCollect>();
        audioManager = AudioManager.Instance;
        controller = FindFirstObjectByType<UIController>();
        finishLine = FindFirstObjectByType<FinishLine>();
    }

    
    void Update()
    {
        HeadCrash();
    }

    private void HeadCrash()
    {
        if (!playerHead.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
 
        if (isGameOver == false && finishLine.GameFinishFix() == false)
        {
            gameOverPanel.SetActive(true);
            fuelController.GameOver();
            playerController.DisableControls();
            coinCollect.StopCollecting(); 
            audioManager.PlayGameOverAudio();
            controller.DisablePause();
            isGameOver = true;
        }
    }
    public void GameRestart()
    {
        gameOverPanel.SetActive(false);
        gameSession.RestartLevel();
    }
    public void Home()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(0);
        audioManager.StopGameAudio();
  
    }
    public bool GameOverFix()
    {
        return isGameOver;  
    }
   
}
