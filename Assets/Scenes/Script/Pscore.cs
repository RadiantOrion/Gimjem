using UnityEngine;
using TMPro; // Wajib untuk UI Teks

public class Pscore : MonoBehaviour
{
    [Header("Skor Game")]
    public int totalSkor = 0;

    [Tooltip("Masukkan objek TeksSkor dari UI ke sini")]
    public TextMeshProUGUI teksSkorUI;

    private float timerTanpaKena = 0f;

    void Start()
    {
        // Tampilkan skor 0 saat awal mulai
        PerbaruiUI();
    }

    void Update()
    {
        // Sistem Eternal Flame (+100 tiap 30 detik)
        timerTanpaKena += Time.deltaTime;

        if (timerTanpaKena >= 30f)
        {
            TambahSkor(100, "Eternal Flame");
            timerTanpaKena = 0f;
        }
    }

    public void TambahSkor(int jumlah, string namaBonus)
    {
        totalSkor += jumlah;
        PerbaruiUI(); // Update teks UI
        Debug.Log($"<color=orange>BONUS! {namaBonus} (+{jumlah})</color>");
    }

    private void PerbaruiUI()
    {
        if (teksSkorUI != null)
        {
            teksSkorUI.text = "Skor: " + totalSkor;
        }
    }

    // SEMUA DETEKSI BONUS DAN TABRAKAN ADA DI DALAM SINI
    private void OnTriggerEnter2D(Collider2D objekSentuh)
    {
        // 1. Deteksi berhasil melewati lilin
        if (objekSentuh.CompareTag("LewatLilin"))
        {
            TambahSkor(10, "Lewati Rintangan");
            objekSentuh.enabled = false;
        }
        // 2. Deteksi area Near Burn
        else if (objekSentuh.CompareTag("NearBurn"))
        {
            TambahSkor(100, "Near Burn");
            objekSentuh.enabled = false;
        }
        // 3. Deteksi area Risk Flame
        else if (objekSentuh.CompareTag("RiskFlame"))
        {
            TambahSkor(300, "Risk Flame");
            objekSentuh.enabled = false;
        }
        // 4. Deteksi tabrakan fisik dengan Lilin (Damage)
        else if (objekSentuh.CompareTag("Lilin"))
        {
            timerTanpaKena = 0f; // Reset timer
            Debug.Log("Aduh Nabrak!");
            // Nanti logika pengurangan HP ditaruh di sini
        }
    }
}