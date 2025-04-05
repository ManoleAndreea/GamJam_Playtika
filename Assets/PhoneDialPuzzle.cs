using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneDialPuzzle : MonoBehaviour
{
    public GameObject receiverImage;
    public Button pickupButton;
    public GameObject phoneBody;
    public List<AudioClip> noteClips;
    public AudioSource audioSource;

    public AudioClip paperSound;

    public RectTransform dial;
    public GameObject paper;
    public CanvasGroup phoneBodyGroup;

    private List<int> inputCode = new List<int>();
    private List<int> correctCode = new List<int> { 3, 5, 2 };

    private float[] dialAngles = new float[] { 0, -36, -72, -108, -144, -180, -216, -252, -288, -324 };

    public void PressDigit(int digit)
    {
        Debug.Log("[Puzzle] Primit digit: " + digit);

        dial.rotation = Quaternion.Euler(0, 0, dialAngles[digit]);
        audioSource.PlayOneShot(noteClips[digit]);
        inputCode.Add(digit);

        Debug.Log("[Puzzle] Cod introdus până acum: " + string.Join(",", inputCode));

        if (inputCode.Count == correctCode.Count)
        {
            CheckCode();
        }
    }

    public void OnPickUpReceiver()
    {
        Debug.Log("[Puzzle] Receptor ridicat!");

        receiverImage.SetActive(true);

        // Ascunde vizual telefonul dar NU afectează funcțional input
        phoneBodyGroup.alpha = 0f;
        phoneBodyGroup.blocksRaycasts = false;
        phoneBodyGroup.interactable = false;

        StartCoroutine(PlayCodeSequenceAndShowPhoneBody());
    }

    IEnumerator PlayCodeSequenceAndShowPhoneBody()
    {
        foreach (int digit in correctCode)
        {
            audioSource.PlayOneShot(noteClips[digit]);
            yield return new WaitForSeconds(0.8f);
        }

        // Afișăm telefonul vizual înapoi
        phoneBodyGroup.alpha = 1f;
        phoneBodyGroup.blocksRaycasts = false;
        phoneBodyGroup.interactable = false;
        receiverImage.SetActive(false);
    }

    void CheckCode()
    {
        bool correct = true;
        for (int i = 0; i < correctCode.Count; i++)
        {
            if (inputCode[i] != correctCode[i])
            {
                correct = false;
                break;
            }
        }

        if (correct)
        {
            Debug.Log("[Puzzle] ✅ Cod corect!");
            paper.SetActive(true);
            audioSource.PlayOneShot(paperSound);
        }
        else
        {
            Debug.Log("[Puzzle] ❌ Cod greșit. Ai introdus: " + string.Join(",", inputCode));
        }

        inputCode.Clear();
    }

    public void PlayCodeSound()
    {
        StartCoroutine(PlayCodeSequence());
    }

    IEnumerator PlayCodeSequence()
    {
        foreach (int digit in correctCode)
        {
            audioSource.PlayOneShot(noteClips[digit]);
            yield return new WaitForSeconds(0.8f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("[DEBUG] SPACE apăsat – PhoneBody activ: " + phoneBody.activeSelf);
        }
    }
}
