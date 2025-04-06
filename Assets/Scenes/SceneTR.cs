using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTR : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1f;
    public string sceneToLoad = "NextScene"; 

    private bool isFading = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFading)
        {
            StartCoroutine(FadeAndLoadScene(sceneToLoad));
        }
    }

    IEnumerator FadeAndLoadScene(string sceneName)
    {
        isFading = true;

        float t = 0;
        Color c = fadePanel.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0, 1, t / fadeDuration);
            fadePanel.color = c;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
