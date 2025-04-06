using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StoryController : MonoBehaviour
{
    public GameObject bellImage;
    public GameObject bellTextboxPanel;
    public TextMeshProUGUI bellText;

    public GameObject grayImage;
    public GameObject grayTextboxPanel;
    public TextMeshProUGUI grayText;

    public GameObject blackFadePanel;
    public AudioSource phoneRing;
    public AudioSource Bell1;

    public AudioSource Bell2;

    public AudioSource Gray1;

    public string nextSceneName = "Scena2";

    void Start()
    {
        // Ascundem totul în afară de Bell la început
        bellImage.SetActive(true);
        bellTextboxPanel.SetActive(true);
        grayImage.SetActive(false);
        grayTextboxPanel.SetActive(false);
        StartCoroutine(PlaySceneSequence());
    }

    IEnumerator PlaySceneSequence()
    {
        // 🧍 Bell zice prima replică
        bellText.text = "This is it... The moment I’ve waited for.";
        Bell1.Play();
        yield return new WaitForSeconds(3.5f);

        // 📞 Telefonul sună
        phoneRing.Play();
        Bell2.Play();
        bellText.text = "Who could be calling me now?";
        yield return new WaitForSeconds(3.5f);

        // 🔄 Bell dispare
        bellTextboxPanel.SetActive(false);
        bellImage.SetActive(false);

        // 👤 Gray apare
        grayImage.SetActive(true);
        grayTextboxPanel.SetActive(true);
        Gray1.Play();
        grayText.text = "Time waits for no one, Bell.";
        yield return new WaitForSeconds(3.5f);

        // 🌫️ Fade + schimbă scena
        yield return StartCoroutine(FadeToBlack());
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator FadeToBlack()
    {
        CanvasGroup cg = blackFadePanel.GetComponent<CanvasGroup>();
        while (cg.alpha < 1f)
        {
            cg.alpha += Time.deltaTime;
            yield return null;
        }
    }
}
