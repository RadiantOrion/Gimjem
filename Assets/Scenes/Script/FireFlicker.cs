using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireFlicker : MonoBehaviour
{
    private Light2D fireLight;
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.2f;
    public float flickerSpeed = 5f;

    void Start()
    {
        fireLight = GetComponent<Light2D>();
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f);
        fireLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

    }
}
