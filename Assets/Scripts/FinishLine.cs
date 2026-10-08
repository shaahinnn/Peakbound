using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishLine : MonoBehaviour
{
    [SerializeField] GameObject nextLevelPage;
    BoxCollider2D boxCollider;
    GameSession gameSession;
    PlayerController playerController;
    FuelController fuelController;
    AudioManager audioManager;
    UIController controller;
    GameOver gameOver;
    bool isFinish = false;

    private void Start()
    {
        nextLevelPage.SetActive(false);
        boxCollider = GetComponent<BoxCollider2D>();
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        gameSession = FindFirstObjectByType<GameSession>();
        playerController = FindFirstObjectByType<PlayerController>();
        fuelController = FindFirstObjectByType<FuelController>();
        audioManager = AudioManager.Instance;
        controller = FindFirstObjectByType<UIController>();
        gameOver = FindFirstObjectByType<GameOver>();

    }
    private void Update()
    {
        if (!boxCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            return;
        }
    
        if (gameOver.GameOverFix() == false && isFinish == false)
        {
            Debug.Log("Finish Line Reached!");
            if(fuelController.FuelGameOverFix() == false)
            {
                nextLevelPage.SetActive(true);
                audioManager.PlayWinAudio();
            }
            playerController.DisableControls();
            fuelController.GameOver();
            controller.DisablePause();
            isFinish = true;
            if(isFinish)
            {
                fuelController.FuelAnimationFix();
            }
        }
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        audioManager.StopGameAudio();
        audioManager.PlayClickAudio();
        Time.timeScale = 1;
    }
    public void RestartLevel()
    {
        gameSession.RestartLevel();
        audioManager.PlayClickAudio();
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        gameSession.NextLevel();
        audioManager.PlayClickAudio();
    }
    public bool GameFinishFix()
    {
        return isFinish;
    }
}
