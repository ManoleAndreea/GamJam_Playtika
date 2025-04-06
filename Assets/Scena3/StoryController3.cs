using System.Collections;
using UnityEngine;
using TMPro;

public class Scene3Intro : MonoBehaviour
{
    [Header("Audio")]
   // public AudioClip r3bell;
    public AudioSource audioSource;

    [Header("Bell UI")]
    public GameObject bellImage;
    public GameObject bellTextboxPanel;
    public TextMeshProUGUI bellText;

    [Header("Gameplay")]
    public GameObject gameplayRoot; // obiectul care conține puzzle-uri, controllere etc.

    void Start()
    {
        // La început: dezactivez gameplay-ul
        gameplayRoot.SetActive(false);

        // Activez dialogul lui Bell
        bellImage.SetActive(true);
        bellTextboxPanel.SetActive(true);
        bellText.text = "Where..., where am I? What are these objects? I should investigate.";

        // Redă replica
       // audioSource.clip = r3bell;
        audioSource.Play();

        // Așteaptă 5 secunde și trece la gameplay
        StartCoroutine(EndIntro());
    }

    IEnumerator EndIntro()
    {
        yield return new WaitForSeconds(5f);

        bellText.text = "";
        bellImage.SetActive(false);
        bellTextboxPanel.SetActive(false);

        gameplayRoot.SetActive(true); // 🎮 dă drumul la joc
    }
}
