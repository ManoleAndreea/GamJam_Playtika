using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class scene3trans:MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration=1f;

    public void StartGameWithFade(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    IEnumerator FadeAndLoadScene(string sceneName)
    {
        float t=0;
        Color c=fadePanel.color;
        while (t<fadeDuration)
        {
            t+=Time.deltaTime;
            c.a=Mathf.Lerp(0, 1, t/fadeDuration);
            fadePanel.color=c;
            yield return null;
        }

    
        SceneManager.LoadScene(sceneName);
    }
}
