using UnityEngine;
using UnityEngine.UI;

public class GlitchEffectSimple : MonoBehaviour
{
    public RectTransform imageTransform;
    public float glitchInterval = 0.3f;
    public float maxOffset = 10f;
    public float duration = 0.05f;

    void Start()
    {
        InvokeRepeating(nameof(DoGlitch), glitchInterval, glitchInterval);
    }

    void DoGlitch()
    {
        Vector3 originalPos=imageTransform.anchoredPosition;
        Vector3 glitchPos=originalPos+new Vector3(Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset), 0);

        imageTransform.anchoredPosition=glitchPos;
        Invoke(nameof(ResetPos), duration);
    }

    void ResetPos()
    {
        imageTransform.anchoredPosition=Vector3.zero;
    }
}
