using UnityEngine;
using TMPro; // Wajib ditambahkan agar bisa mengubah teks UI

public class Pscore : MonoBehaviour
{
    [Header("Skor Game")]
    public int totalSkor = 0;

    [Tooltip("Tarik objek TeksSkor dari Canvas ke kolom ini!")]
    public TextMeshProUGUI teksSkorUI;

    private float timerTanpaKena = 0f;

    void Start()
    {
        // Pastikan skor menunjukkan angka 0 saat game baru dimulai
        PerbaruiUI();
    }

    void Update()
    {
        // Timer otomatis berjalan
        timerTanpaKena += Time.deltaTime;

        // Jika berhasil bertahan 30 detik tanpa menyentuh lilin
        if (timerTanpaKena >= 1f)
        {
            TambahSkor(1, "Keep Alive");
            timerTanpaKena = 0f; // Ulangi timer dari 0
        }
    }

    // Fungsi utama untuk menambah skor dan mengubah teks di layar
    public void TambahSkor(int jumlah, string namaBonus)
    {
        totalSkor += jumlah;
        PerbaruiUI(); // Langsung ubah teks di layar saat ini juga!

        Debug.Log($"<color=orange>BONUS! {namaBonus} (+{jumlah})</color> | Total: {totalSkor}");
    }

    // Fungsi khusus untuk menulis angka ke layar
    private void PerbaruiUI()
    {
        if (teksSkorUI != null)
        {
            teksSkorUI.text = "" + totalSkor;
        }
    }

    // Deteksi saat Player menyentuh zona/garis tak terlihat
    private void OnTriggerEnter2D(Collider2D objekSentuh)
    {
        // 1. Jika menyentuh Garis Lebar (Berhasil melewati rintangan)
        if (objekSentuh.CompareTag("LewatLilin"))
        {
            TambahSkor(10, "Lewati Rintangan");
            objekSentuh.enabled = false; // Matikan garis agar tidak dapat skor berkali-kali
        }

        // 2. Jika menyentuh zona transparan di pinggir lilin
        else if (objekSentuh.CompareTag("NearBurn"))
        {
            TambahSkor(100, "Near Burn");
            objekSentuh.enabled = false;
        }

        // 3. Jika melewati celah sempit
        else if (objekSentuh.CompareTag("RiskFlame"))
        {
            TambahSkor(300, "Risk Flame");
            objekSentuh.enabled = false;
        }

        // 4. Jika menabrak badan utama lilin (Damage)
        else if (objekSentuh.CompareTag("Lilin"))
        {
            timerTanpaKena = 0f; // Reset timer karena menabrak
            Debug.Log("Aduh Nabrak Lilin!");
            // (Nanti logika kurangi HP dimasukkan ke sini)
            // SISTEM PENINGKAT KECEPATAN OTOMATIS
            // Batasi kecepatan maksimal (misalnya 2.5x lipat) agar game tetap bisa dimainkan
            if (Time.timeScale < 2.5f)
            {
                // Tambah kecepatan 1% (0.01f) setiap detiknya
                Time.timeScale += 0.01f * Time.deltaTime;
            }
        }

    }

}