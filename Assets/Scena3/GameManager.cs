using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        // Oprește progresul vechi la fiecare start de joc (dacă vrei)
        // PlayerPrefs.DeleteKey("PuzzleTelefonRezolvat");

        // Dacă vrei să păstrezi GameManager-ul între scene:
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Test: apasă R ca să resetezi progresul
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("PuzzleTelefonRezolvat");
            Debug.Log("🔄 Progresul a fost resetat!");
        }
    }
}
