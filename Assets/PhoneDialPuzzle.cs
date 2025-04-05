using System.Collections.Generic;
using UnityEngine;

public class PhoneDialPuzzle : MonoBehaviour
{
    public List<AudioClip> noteClips; 
    public AudioSource audioSource;
    public RectTransform dial;
    public GameObject paper;

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

    System.Collections.IEnumerator PlayCodeSequence()
    {
        foreach (int digit in correctCode)
        {
            audioSource.PlayOneShot(noteClips[digit]);
            yield return new WaitForSeconds(0.8f);
        }
    }
}
