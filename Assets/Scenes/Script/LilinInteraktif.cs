using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LilinInteraktif : MonoBehaviour
{
    [Header("Komponen Visual")]
    public Light2D cahayaLilin;
    public Animator lilinAnimator;


    [Header("Komponen Audio (Suara)")]
    public AudioSource sumberSuara;
    public AudioClip efekSuaraMenyala;

    // Tambahkan referensi ke Animator

    private bool sudahMenyala = false;

    void Start()
    {
        // Memastikan cahaya mati saat game dimulai
        if (cahayaLilin != null)
        {
            cahayaLilin.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D objekYangMenabrak)
    {
        if (objekYangMenabrak.CompareTag("Api") && !sudahMenyala)
        {
            SistemHPApi hpApi = objekYangMenabrak.GetComponent<SistemHPApi>();

            if (hpApi != null)
            {
                hpApi.KurangiHP();
            }

            NyalakanLilin();
        }
    }

    void NyalakanLilin()
    {
        sudahMenyala = true;

        // 1. Hidupkan Point Light 2D
        if (cahayaLilin != null)
        {
            cahayaLilin.enabled = true;
        }

        // 2. Picu Animasi Lilin Menyala
        if (lilinAnimator != null)
        {
            // Memanggil parameter Trigger yang kita buat di Animator
            lilinAnimator.SetTrigger("Nyalakan");
        }

        if (sumberSuara != null && efekSuaraMenyala != null)
        {
            sumberSuara.PlayOneShot(efekSuaraMenyala);
        }
    }
}