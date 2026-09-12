using UnityEngine;
using UnityEngine.SceneManagement; // Wajib ditambahkan untuk fungsi mengulang/berpindah Scene

public class SistemHPApi : MonoBehaviour
{
    [Header("Pengaturan HP")]
    public int nyawa = 3;

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
        Debug.Log("GAME OVER! Lilin yang disentuh sudah maksimal.");

        // Cara paling umum untuk Game Over: Mengulang level saat ini dari awal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Catatan: Jika Anda ingin memunculkan layar UI Game Over, 
        // Anda bisa memanggil fungsi UI Anda di sini dan menggunakan "Time.timeScale = 0;" 
        // untuk menghentikan pergerakan game.
    }
}