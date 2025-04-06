using UnityEngine;

public class PuzzleProgressChecker : MonoBehaviour
{
    public GameObject bonusImage; // imaginea care apare după puzzle 2

    void Start()
    {
        if (PlayerPrefs.GetInt("Puzzle2Completed", 0) == 1)
        {
            bonusImage.SetActive(true);
        }
        else
        {
            bonusImage.SetActive(false);
        }
    }
}
