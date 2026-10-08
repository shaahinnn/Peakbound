using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject musicOffButton;
    [SerializeField] GameObject musicOnButton;
    UIManager manager;
    bool isPause = true;
    AudioManager audioManager;
    GameOver gameOver;
    FinishLine finishLine;
    FuelController fuelController;
 
    void Start()
    {
        Time.timeScale = 1;
        gameOver = FindAnyObjectByType<GameOver>(FindObjectsInactive.Include);
        finishLine = FindAnyObjectByType<FinishLine>();    
        fuelController = FindFirstObjectByType<FuelController>();
        pausePanel.SetActive(false);
        audioManager = AudioManager.Instance;
        audioManager.PlayGameAudio();
        audioManager.StopHomeAudio();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.GameOverFix() == true || finishLine.GameFinishFix() == true || fuelController.FuelFix() == true)
        {
            audioManager.StopGameAudio();
        }
    }
    public void PauseButton()
    {
        if(isPause)
        {
            pausePanel.SetActive(true);
            audioManager.PlayClickAudio();
            Time.timeScale = 0;
        }
    }
    public void ExitPauseButton()
    {
        pausePanel.SetActive(false);
        audioManager.PlayClickAudio();
        Time.timeScale = 1;
    }
    public void DisablePause()
    {
        isPause = false;
    }
    public void MusicOn()
    {
        musicOnButton.SetActive(false);
        audioManager.PlayClickAudio();
        audioManager.StopMusic();
    }
    public void MusicOff()
    {
        musicOnButton.SetActive(true);
        audioManager.PlayClickAudio();
        audioManager.PlayGameMusic();
    }
}
