using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GoToScene1()
    {
        SceneManager.LoadScene("1");
    }
}
