using UnityEngine;

public class BatasLayar : MonoBehaviour
{

    public float batasKiri = -8f;
    public float batasKanan = 8f;

    public float batasBawah = -4.5f;
    public float batasAtas = 4.5f;

    void LateUpdate()
    {
        Vector3 posisiPlayer = transform.position;

        posisiPlayer.x = Mathf.Clamp(posisiPlayer.x, batasKiri, batasKanan);

      
        posisiPlayer.y = Mathf.Clamp(posisiPlayer.y, batasBawah, batasAtas);

        transform.position = posisiPlayer;
    }
}