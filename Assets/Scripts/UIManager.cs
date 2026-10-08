using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] GameObject settingsPage;
    [SerializeField] GameObject musicOnButton;
    [SerializeField] GameObject controlPage;
    bool isSettings = false;
    bool isControls = false;
 
    void Start()
    {
        settingsPage.SetActive(false);
        controlPage.SetActive(false);
        audioManager = AudioManager.Instance;
        audioManager.PlayHomeAudio();
        audioManager.StopGameAudio();
    }

    public void StartGame()
    {
        if(isSettings == false || isControls == false)
        {
            SceneManager.LoadScene(1);
            audioManager.StopHomeAudio();
            audioManager.PlayClickAudio();
        }
        audioManager.StopGameAudio();
    }
    public void QuitGame()
    {
        Application.Quit();
        audioManager.PlayClickAudio();
    }
    public void SettingsPage()
    {
        settingsPage.SetActive(true);
        audioManager.PlayClickAudio();
        isSettings = true;
    }
    public void Quit()
    {
        Application.Quit();
        audioManager.PlayClickAudio();
    }
    public void Exit()
    {
        settingsPage.SetActive(false);
        audioManager.PlayClickAudio();
        isSettings = false;
    }
    public void ControlExit()
    {
        controlPage.SetActive(false);
        audioManager.PlayClickAudio();
        isControls = false;
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
        audioManager.PlayHomeMusic();
    }
    public void ControlPage()
    {
        controlPage.SetActive(true);
        audioManager.PlayClickAudio();
        isControls = true;
    }
}
