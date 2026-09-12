using UnityEngine;
using UnityEngine.Rendering.Universal; // Wajib ditambahkan untuk Light 2D di URP

public class Glow2D : MonoBehaviour
{
    public Light2D playerLight;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    public float glowSpeed = 2f;

    void Start()
    {
        if (playerLight == null)
        {
            playerLight = GetComponent<Light2D>();
        }
    }

    void Update()
    {
        if (playerLight != null)
        {
            float glow = Mathf.Sin(Time.time * glowSpeed);
            playerLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, (glow + 1f) / 2f);
        }
    }
}