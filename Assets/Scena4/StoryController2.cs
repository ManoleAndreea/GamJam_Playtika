using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class StoryController2 : MonoBehaviour
{
    [Header("Audio Sources (vocea direct pe fiecare)")]
    public AudioSource r2gray;
    public AudioSource r3gray;
    public AudioSource r4bell;

    [Header("Gray UI")]
    public GameObject grayImage;
    public GameObject grayTextboxPanel;
    public TextMeshProUGUI grayText;

    [Header("Bell UI")]
    public GameObject bellImage;
    public GameObject bellTextboxPanel;
    public TextMeshProUGUI bellText;

    void Start()
    {

        grayImage.SetActive(false);
        grayTextboxPanel.SetActive(false);
        bellImage.SetActive(false);
        bellTextboxPanel.SetActive(false);

        StartCoroutine(PlayDialogSequence());
    }

    IEnumerator PlayDialogSequence()
    {

        grayImage.SetActive(true);
        grayTextboxPanel.SetActive(true);
        grayText.text = "Fascinating, isn’t it? Even when time fractures, you still manage to be first.";
        r2gray.Play();
        yield return new WaitForSeconds(r2gray.clip.length);
        grayText.text = "I gave the world a voice, Bell... but it was your name they remembered. Now, you’ll walk through the echoes of stolen time—each puzzle a fragment of the truth you rewrote.";
        r3gray.Play();
        yield return new WaitForSeconds(r3gray.clip.length);
        grayText.text = ""; 
        grayImage.SetActive(false);
        grayTextboxPanel.SetActive(false);
        bellImage.SetActive(true);
        bellTextboxPanel.SetActive(true);
        bellText.text = "Gray...? I haven’t seen him in years. The last thing I remember is that he was working on a telephone too... trying to patent it.";
        r4bell.Play();
        yield return new WaitForSeconds(r4bell.clip.length);
        SceneManager.LoadScene("Scena3");
    }
}
