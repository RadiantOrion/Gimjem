using UnityEngine;
using UnityEngine.SceneManagement; // Wajib ditambahkan untuk fungsi mengulang/berpindah Scene

public class SistemHPApi : MonoBehaviour
{
    [Header("Pengaturan HP")]
    public int nyawa = 3;

    [Header("UI Game Over")]
    public GameObject layarGameOver;

    void Start()
    {
        // Pastikan UI disembunyikan dan waktu berjalan normal saat mulai
        if (layarGameOver != null) layarGameOver.SetActive(false);
        Time.timeScale = 1f;
    }

    // Fungsi ini akan dipanggil oleh lilin saat bersentuhan
    public void KurangiHP()
    {
        nyawa--; // Kurangi nyawa sebanyak 1
        Debug.Log("Sisa Nyawa Api: " + nyawa);

        if (nyawa <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Munculkan layar UI dan hentikan waktu (Pause)
        if (layarGameOver != null) layarGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void KlikRestart()
    {
        Time.timeScale = 1f; // Kembalikan waktu berjalan normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void KlikMainMenu()
    {
        Time.timeScale = 1f;

        // MENCARI DAN MENGHANCURKAN BGM GAMEPLAY
        // Pastikan nama di dalam tanda kutip ini sama persis dengan 
        // nama GameObject BGM Anda di Scene permainan.
        GameObject bgmGameplay = GameObject.Find("BackgroundMusic");
        if (bgmGameplay != null)
        {
            Destroy(bgmGameplay);
        }

        Time.timeScale = 1f; // Kembalikan waktu berjalan normal
        // Ganti "MenuUtama" dengan nama Scene menu Anda nanti
        SceneManager.LoadScene("MenuUtama");
    }
}