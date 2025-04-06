using UnityEngine;
using UnityEngine.SceneManagement;
public class LockController : MonoBehaviour
{
    public Dial dial1;
    public Dial dial2;
    public Dial dial3;
    public Dial dial4;

    public GameObject cufarInchis;
    public GameObject cufarDeschis;
    public GameObject lockObject; // grupul cu tamburii

    public AudioClip unlockSound;
    private AudioSource audioSource;

    private bool unlocked = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!unlocked && IsCorrectCode())
        {
            UnlockCufar();
        }
    }

    bool IsCorrectCode()
    {
        return dial1.GetCurrentIndex() == 1 &&
               dial2.GetCurrentIndex() == 2 &&
               dial3.GetCurrentIndex() == 5 &&
               dial4.GetCurrentIndex() == 4;
    }

    void UnlockCufar()
    {
        unlocked = true;

        if (lockObject != null)
            lockObject.SetActive(false);

        if (cufarInchis != null)
            cufarInchis.SetActive(false);

        if (cufarDeschis != null)
            cufarDeschis.SetActive(true);

        if (audioSource != null && unlockSound != null)
            audioSource.PlayOneShot(unlockSound);

        Debug.Log("✅ Cufărul a fost deblocat cu codul 1254!");

        Invoke("GoToNextScene", 2f);
    }
    void GoToNextScene()
    {
        SceneManager.LoadScene("Scena5");
    }
}
