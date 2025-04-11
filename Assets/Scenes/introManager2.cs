using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class introManager2 : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public float delayBetweenChars = 0.03f;
    public float waitAfterText = 5f; // timp până se trece la scena 2
    public string nextSceneName = "Scena8"; // numele exact al scenei următoare

    private string fullText = "The final puzzle clicks into place. A soft hum fills the air as the phone begins to ring—one last time. Bell hesitates, then lifts the receiver. In a flash of light and sound, he's pulled back through the fissures of time.Back in his dimly lit workshop, everything is just as he left it... except now, history remembers only him. The patent bears his name. The headlines call him a visionary.";

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
