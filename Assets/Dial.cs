using UnityEngine;

public class Dial : MonoBehaviour
{
    public GameObject[] symbolObjects;   // Cifrele (0–9) ca child objects
    public AudioClip clickSound;         // Sunet la rotire

    private AudioSource audioSource;
    private int currentIndex = 0;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShowOnlyCurrentSymbol();
    }

    void OnMouseDown()
    {
        startTouchPosition = Input.mousePosition;
    }

    void OnMouseUp()
    {
        endTouchPosition = Input.mousePosition;
        Vector2 delta = endTouchPosition - startTouchPosition;

        if (Mathf.Abs(delta.y) > Mathf.Abs(delta.x)) // Swipe vertical
        {
            if (delta.y > 0)
                RotateUp();
            else
                RotateDown();
        }
    }

    void RotateUp()
    {
        currentIndex = (currentIndex + 1) % symbolObjects.Length;
        ShowOnlyCurrentSymbol();
        PlaySound();
        AnimateRotate(true);
    }

    void RotateDown()
    {
        currentIndex = (currentIndex - 1 + symbolObjects.Length) % symbolObjects.Length;
        ShowOnlyCurrentSymbol();
        PlaySound();
        AnimateRotate(false);
    }

    void ShowOnlyCurrentSymbol()
    {
        for (int i = 0; i < symbolObjects.Length; i++)
        {
            symbolObjects[i].SetActive(i == currentIndex);
        }
    }

    void PlaySound()
    {
        if (audioSource && clickSound)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    void AnimateRotate(bool isUp)
    {
        StopAllCoroutines();
        StartCoroutine(RotateEffect(isUp));
    }

    System.Collections.IEnumerator RotateEffect(bool isUp)
    {
        float t = 0f;
        float duration = 0.1f;
        float angle = isUp ? -25f : 25f; // rotire realistă în sus sau jos

        Quaternion originalRot = transform.localRotation;
        Quaternion targetRot = Quaternion.Euler(angle, 0, 0);

        // Rotim în direcția swipe-ului
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.localRotation = Quaternion.Lerp(originalRot, targetRot, t / duration);
            yield return null;
        }

        t = 0f;

        // Revenim la poziția normală
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.localRotation = Quaternion.Lerp(targetRot, originalRot, t / duration);
            yield return null;
        }

        transform.localRotation = originalRot;
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }
}
 