using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlitchUIButton : MonoBehaviour
{
    public RectTransform buttonTransform;
    public TextMeshProUGUI buttonText;
    public Image buttonImage;

    public float glitchFrequency = 2f;
    public float glitchDuration = 0.08f;
    public Color[] glitchColors;

    private Vector3 originalPos;
    private Color originalColor;

    void Start()
    {
        originalPos = buttonTransform.anchoredPosition;
        originalColor = buttonText.color;
        InvokeRepeating(nameof(DoGlitch), glitchFrequency, glitchFrequency);
    }

    void DoGlitch()
    {
        float offset = Random.Range(-4f, 4f);
        buttonTransform.anchoredPosition = originalPos + new Vector3(offset, offset, 0);

        if (glitchColors.Length > 0)
        {
            buttonText.color = glitchColors[Random.Range(0, glitchColors.Length)];
            if (buttonImage != null)
                buttonImage.color = glitchColors[Random.Range(0, glitchColors.Length)];
        }

        Invoke(nameof(ResetGlitch), glitchDuration);
    }

    void ResetGlitch()
    {
        buttonTransform.anchoredPosition = originalPos;
        buttonText.color = originalColor;
        if (buttonImage != null)
            buttonImage.color = Color.white;
    }
}
