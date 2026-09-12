using UnityEngine;

public class ParallaxFisikVertikal : MonoBehaviour
{
    [Header("Pengaturan Gerak")]
    [Tooltip("Kecepatan: Positif (+) = Background Naik | Negatif (-) = Background Turun")]
    public float speed = -3f;

    private float tinggiBackground;
    private Vector3 posisiAwal;

    void Start()
    {
        posisiAwal = transform.position;

        Renderer meshRend = GetComponent<Renderer>();
        if (meshRend != null)
        {
            tinggiBackground = meshRend.bounds.size.y;
        }
        else
        {
            tinggiBackground = 10f;
        }
    }

    void Update()
    {
        if (tinggiBackground <= 0) return;

        // Rumus super stabil: menghitung sisa jarak dan langsung menambahkannya
        float offset = (Time.time * speed) % tinggiBackground;

        // Perhatikan tanda + (tambah) di sini, ini yang mencegah background hilang!
        transform.position = new Vector3(posisiAwal.x, posisiAwal.y + offset, posisiAwal.z);
    }
}