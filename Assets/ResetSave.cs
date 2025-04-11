using UnityEngine;

public class ResetSave : MonoBehaviour
{

    public void Resetall()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
