using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public float delayBetweenChars = 0.03f;
    public float waitAfterText = 5f; // timp până se trece la scena 2
    public string nextSceneName = "Scena2"; // numele exact al scenei următoare

    private string fullText = "In 1876, a voice traveled through wires for the very first time.It was the voice of Alexander Graham Bell — a man driven by invention, curiosity, and the desire to connect the world. That moment changed everything.What began as a spark of innovation became a revolution in communication. But what if something went wrong? What if time… glitched?";

    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        introText.text = "";

        foreach (char c in fullText)
        {
            introText.text += c;
            yield return new WaitForSeconds(delayBetweenChars);
        }

        yield return new WaitForSeconds(waitAfterText);

        SceneManager.LoadScene(nextSceneName);
    }
}
