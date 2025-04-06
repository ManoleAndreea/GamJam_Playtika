using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class StoryController6 : MonoBehaviour
{

    public AudioSource r6gray;
    public GameObject grayImage;
    public GameObject grayTextboxPanel;
    public TextMeshProUGUI grayText;
    

    void Start()
    {
        StartCoroutine(PlayDialogSequence());
    }
    IEnumerator PlayDialogSequence()
    {

        grayImage.SetActive(false);
        grayTextboxPanel.SetActive(false);
        grayImage.SetActive(true);
        grayTextboxPanel.SetActive(true);
        grayText.text = "You always were... just fast enough. But speed doesn’t cleanse the stain.";
        r6gray.Play();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Scena7");
    }
    
    }