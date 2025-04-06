using System.Collections;
using UnityEngine;
using TMPro;

public class Scene3Intro : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    [Header("Bell UI")]
    public GameObject bellImage;
    public GameObject bellTextboxPanel;
    public TextMeshProUGUI bellText;

    [Header("Gameplay")]
    public GameObject gameplayRoot;

    void Start()
    {
        // Verificăm dacă intro-ul a fost deja jucat
        if (PlayerPrefs.GetInt("Scene3IntroPlayed", 0) == 1)
        {
            // Dacă da, trecem direct la gameplay
            bellImage.SetActive(false);
            bellTextboxPanel.SetActive(false);
            gameplayRoot.SetActive(true);
        }
        else
        {
            // Dacă nu, rulăm intro-ul
            gameplayRoot.SetActive(false);
            bellImage.SetActive(true);
            bellTextboxPanel.SetActive(true);
            bellText.text = "Where..., where am I? What are these objects? I should investigate.";

            audioSource.Play();
            StartCoroutine(EndIntro());
        }
    }

    IEnumerator EndIntro()
    {
        yield return new WaitForSeconds(5f);

        bellText.text = "";
        bellImage.SetActive(false);
        bellTextboxPanel.SetActive(false);

        gameplayRoot.SetActive(true);

        // ✅ Marcăm că intro-ul a fost redat
        PlayerPrefs.SetInt("Scene3IntroPlayed", 1);
        PlayerPrefs.Save();
    }
}
