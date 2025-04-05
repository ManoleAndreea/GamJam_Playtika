using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneIntroFade : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration=1f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float t=0;
        Color c=fadePanel.color;
        while (t<fadeDuration)
        {
            t+=Time.deltaTime;
            c.a=Mathf.Lerp(1, 0, t/fadeDuration);
            fadePanel.color=c;
            yield return null;
        }
        fadePanel.gameObject.SetActive(false); 
    }
}
