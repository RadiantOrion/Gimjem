using UnityEngine;

public class ParallaxWadah : MonoBehaviour
{
    [Header("Pengaturan Gerak")]
    [Tooltip("Positif (+) = Naik, Negatif (-) = Turun")]
    public float speed = -3f;

    [Tooltip("Masukkan TINGGI SATU gambar background (misal: 10)")]
    public float tinggiSatuBackground = 10f;

    private Vector3 posisiAwal;

    void Start()
    {
        posisiAwal = transform.position;
    }

    void Update()
    {
        // Menghitung perputaran angka
        float offset = Mathf.Repeat(Time.time * speed, tinggiSatuBackground);

        // Menggerakkan Wadah-nya. Kedua background di dalamnya akan ikut bergerak tanpa terpisah.
        transform.position = new Vector3(posisiAwal.x, posisiAwal.y + offset, posisiAwal.z);
    }
}