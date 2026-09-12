using UnityEngine;

public class ObstacleSpawnerDiam : MonoBehaviour
{
    [Header("Pengaturan Prefab Rintangan")]
    public GameObject obstaclePrefab;

    [Header("Waktu & Kecepatan")]
    [Tooltip("Seberapa sering rintangan baru muncul (detik)")]
    public float spawnInterval = 2f;

    [Tooltip("PENTING: Samakan persis dengan angka 'speed' pada script Parallax Background Anda agar rintangan terlihat DIAM!")]
    public float backgroundSpeed = 3f;

    [Header("Batas Posisi Horizontal (X) & Titik Muncul (Y)")]
    public float minX = -7f;
    public float maxX = 7f;
    public float spawnY = 7f; // Muncul di atas layar, lalu turun mengikuti background agar diam

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefab == null)
        {
            Debug.LogError("ERROR: Obstacle Prefab belum dimasukkan di Inspector GameManager!");
            return;
        }

        // Tentukan posisi X secara acak
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        // Munculkan rintangan
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Tempelkan script pengunci posisi agar ikut bergerak turun seirama background (sehingga terlihat DIAM)
        ObstacleDiamLock lockScript = newObstacle.AddComponent<ObstacleDiamLock>();
        lockScript.speed = backgroundSpeed;
    }
}

// Sub-script untuk mengunci rintangan agar seolah-olah diam di tempat
public class ObstacleDiamLock : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        // Bergerak ke bawah mengikuti arah background, sehingga relatif terhadap player yang "jatuh", rintangan ini tampak DIAM.
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Hapus otomatis jika sudah lewat di bawah layar (Y < -7) agar hemat memori
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}