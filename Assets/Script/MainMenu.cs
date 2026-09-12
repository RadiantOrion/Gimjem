using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    public int SampleScene { get; private set; }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}