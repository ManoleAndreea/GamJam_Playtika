using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PuzzleTimerUI : MonoBehaviour
{
    public float timeLimitMinutes = 30f;
    private float startTime;
    private bool expired = false;
    private bool warned = false;

    public string sceneOnTimeout = "MainMenu";

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI warningText;

    private static PuzzleTimerUI instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // persistă între scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        startTime = Time.time;
        if (warningText != null)
            warningText.gameObject.SetActive(false);
    }
    void TryReconnectUI()
{
    if (timerText == null)
    {
        GameObject found = GameObject.Find("TimerText");
        if (found != null)
        {
            timerText = found.GetComponent<TextMeshProUGUI>();
            Debug.Log("✅ TimerText reatașat automat.");
        }
    }

    if (warningText == null)
    {
        GameObject foundWarn = GameObject.Find("WarningText");
        if (foundWarn != null)
        {
            warningText = foundWarn.GetComponent<TextMeshProUGUI>();
            warningText.gameObject.SetActive(false);
        }
    }
}


    void Update()
    {
        float elapsed = Time.time - startTime;
        float remaining = (timeLimitMinutes * 60f) - elapsed;

        TryReconnectUI();
        
        // Actualizează textul vizual
        if (timerText != null)
        {
            int mins = Mathf.FloorToInt(remaining / 60f);
            int secs = Mathf.FloorToInt(remaining % 60f);
            timerText.text = $"Time Left: {mins:D2}:{secs:D2}";
        }
        

        // Warning la 5 minute rămase
        if (!warned && remaining <= 100f)
        {
            warned = true;
            if (warningText != null)
                warningText.gameObject.SetActive(true);
            Debug.Log("⚠️ Aproape de timeout! Mai sunt 5 minute.");
        }

        // Timeout
        if (!expired && elapsed >= timeLimitMinutes * 60f)
        {
            expired = true;
            Debug.Log("⏰ Timpul a expirat! Se revine la scenă...");
            SceneManager.LoadScene(sceneOnTimeout);
        }
    }
}
