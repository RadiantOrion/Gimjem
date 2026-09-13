using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public Rigidbody2D rbApi;
    public string namaScene;

    public GameObject UiPopUp;
    public bool SedangAktif = false;
    
    public void MulaiGame()
    {
        rbApi.bodyType = RigidbodyType2D.Dynamic;
        PanggilSequence();
    }

    public void PanggilSequence()
    {
        StartCoroutine(SeqeuncePindahScene());
    }

    public IEnumerator SeqeuncePindahScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(namaScene);
    }

    public void MunculkanPopup()
    {
        SedangAktif = !SedangAktif;

        if (SedangAktif == true)
        {
            UiPopUp.SetActive(true);

        } else
        {
            UiPopUp.SetActive(false);
        }

    }
    

}
