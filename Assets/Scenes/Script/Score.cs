using UnityEngine;
using TMPro; // Wajib ditambahkan untuk memanggil TextMeshPro

public class SistemSkor : MonoBehaviour
{
    [Header("Skor Game")]
    public int totalSkor = 0;

    [Tooltip("Masukkan objek TeksSkor dari UI ke sini")]
    public TextMeshProUGUI teksSkorUI;

    private float timerTanpaKena = 0f;

    void Start()
    {
        // Tampilkan skor 0 saat game pertama kali dimulai
        PerbaruiUI();
    }

    void Update()
    {
        // Sistem Eternal Flame (+100 tiap 30 detik tidak menyentuh lilin)
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
        PerbaruiUI(); // Langsung ubah teks di layar setiap kali dapat skor

        Debug.Log($"<color=orange>BONUS! {namaBonus} (+{jumlah})</color>");
    }

    public void ResetTimerLilin()
    {
        timerTanpaKena = 0f;
    }

    // Fungsi khusus untuk mengubah tulisan di UI
    private void PerbaruiUI()
    {
        if (teksSkorUI != null)
        {
            teksSkorUI.text = "" + totalSkor;
        }
    }
}