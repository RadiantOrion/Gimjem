using UnityEngine;

public class SpawnerLilin : MonoBehaviour
{
    [Header("Pengaturan Lilin")]
    public GameObject lilinPrefab;

    [Header("Waktu & Kecepatan")]
    [Tooltip("Jeda waktu antar spawn lilin (detik)")]
    public float intervalSpawn = 2f;

    [Tooltip("PENTING: Samakan angka ini dengan kecepatan Background Anda!")]
    public float kecepatanGerak = 3f;

    [Header("Area Muncul (Dari Bawah)")]
    public float batasKiriX = -7f;
    public float batasKananX = 7f;
    public float titikMunculY = -7f; // Di bawah layar
    public float titikHancurY = 7f;  // Di atas layar

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= intervalSpawn)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        if (lilinPrefab == null) return;

        // Acak posisi horizontal (kiri-kanan)
        float acakX = Random.Range(batasKiriX, batasKananX);
        Vector3 posisiMuncul = new Vector3(acakX, titikMunculY, 0f);

        // Buat objek lilin
        GameObject lilinBaru = Instantiate(lilinPrefab, posisiMuncul, Quaternion.identity);

        // Pasang script pergerakan ke atas secara otomatis
        GerakLilin gerak = lilinBaru.AddComponent<GerakLilin>();
        gerak.kecepatan = kecepatanGerak;
        gerak.batasAtas = titikHancurY;
    }
}

// Script ini menempel langsung ke lilin yang baru muncul
public class GerakLilin : MonoBehaviour
{
    public float kecepatan;
    public float batasAtas;

    void Update()
    {
        // Gerak ke ATAS
        transform.Translate(Vector3.up * kecepatan * Time.deltaTime);

        // Hapus jika sudah lewat di atas layar (hemat memori)
        if (transform.position.y > batasAtas)
        {
            Destroy(gameObject);
        }
    }
}