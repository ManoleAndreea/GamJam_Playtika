using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDMenuManager : MonoBehaviour
{
    [Header("UI Buttons")]
    public Button openHUDButton;
    public Button closeHUDButton;
    public GameObject hudPanel;

    public Button pauseButton;
    public Button restartButton;
    public Button musicButton;

    [Header("Music")]
    public AudioSource musicSource;

    private bool isPaused = false;
    private bool musicOn = true;

    void Start()
    {
        // Setare inițială
        hudPanel.SetActive(false);
        openHUDButton.gameObject.SetActive(true);
        closeHUDButton.gameObject.SetActive(true);

        // Listeners
        openHUDButton.onClick.AddListener(ShowHUD);
        closeHUDButton.onClick.AddListener(HideHUD);
        pauseButton.onClick.AddListener(TogglePause);
        restartButton.onClick.AddListener(RestartPuzzle);
        musicButton.onClick.AddListener(ToggleMusic);
    }

    void ShowHUD()
    {
        hudPanel.SetActive(true);
        openHUDButton.gameObject.SetActive(false);
        closeHUDButton.gameObject.SetActive(true);
    }

    void HideHUD()
    {
        hudPanel.SetActive(false);
        openHUDButton.gameObject.SetActive(true);
        closeHUDButton.gameObject.SetActive(false);
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        pauseButton.GetComponentInChildren<Text>().text = isPaused ? "Resume" : "Pause";
    }

    void RestartPuzzle()
    {
        Time.timeScale = 1f; // important dacă era pe pauză
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

    void ToggleMusic()
    {
        musicOn = !musicOn;
        if (musicSource != null)
        {
            musicSource.mute = !musicOn;
        }

        musicButton.GetComponentInChildren<Text>().text = musicOn ? "Music Off" : "Music On";
    }
}
