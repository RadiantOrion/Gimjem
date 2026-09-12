using UnityEngine;

public class DeteksiBonus : MonoBehaviour
{
    private SistemApi sistemApi;

    void Start()
    {
        sistemApi = GetComponent<SistemApi>();
    }

    // Fungsi bawaan Unity saat Player memasuki area "Is Trigger"
    private void OnTriggerEnter2D(Collider2D objekYangDisentuh)
    {
        if (objekYangDisentuh.CompareTag("NearBurn"))
        {
            sistemApi.TambahSkor(100, "Near Burn");
        }
        else if (objekYangDisentuh.CompareTag("RiskFlame"))
        {
            sistemApi.TambahSkor(300, "Risk Flame");
        }
    }
}