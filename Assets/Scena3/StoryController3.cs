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
       
        if (PlayerPrefs.GetInt("Scene3IntroPlayed", 0) == 1)
        {
            bellImage.SetActive(false);
            bellTextboxPanel.SetActive(false);
            gameplayRoot.SetActive(true);
        }
        else
        {
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
        PlayerPrefs.SetInt("Scene3IntroPlayed", 1);
        PlayerPrefs.Save();
    }
}
