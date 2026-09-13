using UnityEngine;

public class BGMManager : MonoBehaviour
{
    // Menyimpan referensi ke BGM yang sedang aktif
    private static BGMManager instance;

    void Awake()
    {
        // Jika belum ada lagu yang terputar...
        if (instance == null)
        {
            instance = this;
            // KUNCI UTAMA: Jangan hancurkan objek lagu ini saat Scene di-restart
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Jika sudah ada lagu yang berputar dari permainan sebelumnya, 
            // hancurkan objek lagu "kloningan" yang baru saja mau muncul
            Destroy(gameObject);
        }
    }
}