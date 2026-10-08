using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{
    [SerializeField] GameObject fuelLow;
    public Image fuelFill;
    bool isEmpty = false;

    public float fuel = 1f;
    public float drainSpeed = 0.1f;
    [SerializeField] GameObject gameOverPanel;
    PlayerController playerController;
    AudioManager audioManager;
    FinishLine finishLine;
    bool isGameOver = false;
    bool isFuelFix = false;
    private void Start()
    {
        gameOverPanel.SetActive(false);
        fuelLow.SetActive(false);
        playerController = FindFirstObjectByType<PlayerController>();
        audioManager = AudioManager.Instance;
        finishLine = FindFirstObjectByType<FinishLine>();
    }
    
    public float GetFuel()
    {
        fuel = 1f;
        return fuel;
    }

    void Update()
    {
        if(!isGameOver && isFuelFix == false)
        {
            fuel -= drainSpeed * Time.deltaTime;
            fuel = Mathf.Clamp01(fuel);
            fuelFill.fillAmount = fuel;
            if (fuel <= 0.4f)
            {
                fuelFill.color = Color.red;
                fuelLow.SetActive(true);
            }
            else
            {
                fuelFill.color = Color.green;
                fuelLow.SetActive(false);

            }
            if (fuel <= 0f && !isEmpty)
            {
                isEmpty = true;
                Debug.Log("Fuel Empty!");
                playerController.DisableControls();
                gameOverPanel.SetActive(true);
                isGameOver = true;
                audioManager.PlayGameOverAudio();
                isFuelFix = true;
            }
        }
    }
    public void GameOver()
    {
        isGameOver = true;
    }
    public bool FuelFix()
    {
        return isFuelFix;
    }
    public void FuelAnimationFix()
    {
        fuelLow.SetActive(false);
    }
    public bool FuelGameOverFix()
    {
        return isGameOver;
    }
}
