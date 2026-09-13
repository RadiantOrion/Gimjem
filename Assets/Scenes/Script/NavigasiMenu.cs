using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Wajib untuk menggunakan Coroutine (jeda waktu)

public class NavigasiMenu : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip suaraKlik;

    // Fungsi ini yang akan dipanggil saat tombol di-klik
    public void KlikTombolMulai()
    {
        // 1. Mainkan suara klik
        sfxSource.PlayOneShot(suaraKlik);

        // 2. Jalankan penghitung waktu mundur sebelum pindah scene
        StartCoroutine(JedaPindahScene("NamaSceneGameplayAnda"));
    }

    public void KlikTombolKeluar()
    {
        sfxSource.PlayOneShot(suaraKlik);
        StartCoroutine(JedaKeluarGame());
    }

    // --- SISTEM JEDA WAKTU ---

    IEnumerator JedaPindahScene(string namaScene)
    {
        // Game menunggu selama durasi file audio klik Anda habis
        yield return new WaitForSeconds(suaraKlik.length);

        // Setelah suara selesai, baru scene dipindah
        SceneManager.LoadScene(namaScene);
    }

    IEnumerator JedaKeluarGame()
    {
        yield return new WaitForSeconds(suaraKlik.length);
        Debug.Log("Game Ditutup!");
        Application.Quit(); // Fungsi untuk menutup game (hanya terlihat saat game sudah di-build)
    }
}