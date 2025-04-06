using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class StoryController5 : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource r4gray;
    public AudioSource r5bell;
    public AudioSource r5gray;
    public AudioSource r6bell;

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

        yield return new WaitForSeconds(2.5f);
        grayImage.SetActive(true);
        grayTextboxPanel.SetActive(true);
        grayText.text = "You never looked back, did you? Too busy basking in the applause to hear the silence you left behind. They called you a pioneer. But I was just… too late.";
        r4gray.Play();
        yield return new WaitForSeconds(r4gray.clip.length);
        grayText.text = "";
        grayImage.SetActive(false);
        grayTextboxPanel.SetActive(false);
        bellImage.SetActive(true);
        bellTextboxPanel.SetActive(true);
        bellText.text = "Gray...? I—I didn’t know. I thought we were both working toward the same dream.";
        r5bell.Play();
        yield return new WaitForSeconds(r5bell.clip.length);
        bellText.text = "";
        bellImage.SetActive(false);
        bellTextboxPanel.SetActive(false);
        grayImage.SetActive(true);
        grayTextboxPanel.SetActive(true);
        grayText.text = "We were. Until you made sure it had only your name on it.";
        r5gray.Play();
        yield return new WaitForSeconds(r5gray.clip.length);
        grayText.text = "";
        grayImage.SetActive(false);
        grayTextboxPanel.SetActive(false);
        bellImage.SetActive(true);
        bellTextboxPanel.SetActive(true);
        bellText.text = "He’s rewriting history... One puzzle at a time.";
        r6bell.Play();
        yield return new WaitForSeconds(r6bell.clip.length);
        SceneManager.LoadScene("Scena3");
    }
}
