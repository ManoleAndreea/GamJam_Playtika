using UnityEngine;

public class PuzzleUnlockManager : MonoBehaviour
{
    public GameObject handWithPaperImage;

    void Start()
    {

         if (handWithPaperImage == null)
        {
            Debug.LogWarning("⚠️ handWithPaperImage NU este setat!");
            return;
        }
        if (PlayerPrefs.GetInt("PuzzleTelefonRezolvat", 0) == 1)
        {
            handWithPaperImage.SetActive(true);
        }
        else
        {
            handWithPaperImage.SetActive(false);
        }
    }
}
