using UnityEngine;
using UnityEngine.Rendering.Universal; // Untuk mengontrol cahaya URP 2D

public class SistemApi : MonoBehaviour
{
    [Header("Status Player")]
    public int hp = 3; // 3 = Besar, 2 = Sedang, 1 = Kecil
    public float kecepatanSaatIni = 8f;
    private int pengaliSkor = 2; // Makin besar HP, skor dikali lebih banyak

    [Header("Sistem Skor")]
    public int totalSkor = 0;
    private float timerEternalFlame = 0f;

    [Header("Visual & Cahaya")]
    [Tooltip("Masukkan objek Global Light 2D ke sini")]
    public Light2D cahayaGlobal;

    [Tooltip("Masukkan Point Light 2D milik Player ke sini")]
    public Light2D cahayaPlayer;

    void Start()
    {
        PerbaruiStatusApi();
    }

    void Update()
    {
        // Sistem Timer: +100 Eternal Flame jika bertahan 30 detik
        timerEternalFlame += Time.deltaTime;
        if (timerEternalFlame >= 30f)
        {
            TambahSkor(100, "Eternal Flame");
            timerEternalFlame = 0f; // Reset timer untuk 30 detik berikutnya
        }
    }

    // Fungsi untuk menambah skor (bisa dipanggil dari script lain)
    public void TambahSkor(int jumlah, string namaBonus)
    {
        int skorAkhir = jumlah * pengaliSkor;
        totalSkor += skorAkhir;
        Debug.Log($"<color=yellow>BONUS! {namaBonus} (+{skorAkhir})</color> | Total: {totalSkor}");
    }

    // Panggil fungsi ini jika player terkena damage (hp turun) atau mendapat heal
    public void UbahHP(int perubahan)
    {
        hp += perubahan;
        hp = Mathf.Clamp(hp, 0, 3); // Pastikan HP tidak lebih dari 3 atau kurang dari 0
        PerbaruiStatusApi();
    }

    // Panggil fungsi ini jika Player MENYENTUH lilin (reset timer)
    public void SentuhLilin()
    {
        timerEternalFlame = 0f;
    }

    // Logika Perubahan Wujud Api
    private void PerbaruiStatusApi()
    {
        if (hp == 3) // API BESAR
        {
            kecepatanSaatIni = 8f;     // Cepat
            pengaliSkor = 2;           // Skor Tinggi (x2)
            if (cahayaGlobal != null) cahayaGlobal.intensity = 0.5f; // Layar Terang
            if (cahayaPlayer != null) cahayaPlayer.pointLightOuterRadius = 4f;
        }
        else if (hp == 2) // API SEDANG
        {
            kecepatanSaatIni = 5f;     // Normal
            pengaliSkor = 1;           // Skor Normal (x1)
            if (cahayaGlobal != null) cahayaGlobal.intensity = 0.5f; // Layar Terang
            if (cahayaPlayer != null) cahayaPlayer.pointLightOuterRadius = 3f;
        }
        else if (hp == 1) // API KECIL
        {
            kecepatanSaatIni = 3f;     // Lambat
            pengaliSkor = 1;
            if (cahayaGlobal != null) cahayaGlobal.intensity = 0.05f; // LAYAR GELAP!
            if (cahayaPlayer != null) cahayaPlayer.pointLightOuterRadius = 1.5f; // Cahaya api mengecil
        }
        else if (hp <= 0)
        {
            Debug.Log("API PADAM - GAME OVER");
            // Masukkan logika Game Over di sini
        }
    }
}