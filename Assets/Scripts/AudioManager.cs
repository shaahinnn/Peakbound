using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioSource homeAudio;
    [SerializeField] AudioSource gameAudio;
    [SerializeField] AudioSource coinAudio;
    [SerializeField] AudioSource fuelAudio;
    [SerializeField] AudioSource headCrackAudio;
    [SerializeField] AudioSource winAudio;
    [SerializeField] AudioSource gameOverAudio;
    [SerializeField] AudioSource clickAudio;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayHomeAudio()
    {
        homeAudio.Play();
    }

    public void StopHomeAudio()
    {
        homeAudio.Stop();
    }

    public void PlayGameAudio()
    {
        gameAudio.Play();
    }

    public void StopGameAudio()
    {
        gameAudio.Stop();
    }

    public void PlayCoinAudio()
    {
        coinAudio.Play();
    }

    public void PlayFuelAudio()
    {
        fuelAudio.Play();
    }

    public void PlayWinAudio()
    {
        winAudio.Play();
    }

    public void PlayGameOverAudio()
    {
        gameOverAudio.Play();
    }

    public void StopMusic()
    {
        homeAudio.Stop();
        gameAudio.Stop();
    }

    public void PlayHomeMusic()
    {
        homeAudio.Play();
        gameAudio.Stop();
    }

    public void PlayGameMusic()
    {
        gameAudio.Play();
        homeAudio.Stop();
    }
    public void PlayClickAudio()
    {
        clickAudio.Play();
    }
}