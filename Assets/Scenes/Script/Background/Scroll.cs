using UnityEngine;

public class InfiniteBackgroundScroll : MonoBehaviour
{
    [Header("Pengaturan Scroll")]
    [Tooltip("Kecepatan scroll tekstur. Angka positif membuat tekstur seolah bergerak ke bawah (kamera naik). Angka negatif sebaliknya.")]
    public float scrollSpeed = 0.5f;

    private Renderer bgRenderer;
    private Vector2 savedOffset;

    void Start()
    {
        bgRenderer = GetComponent<Renderer>();
        savedOffset = bgRenderer.material.mainTextureOffset;
    }

    void Update()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1f);
        Vector2 offset = new Vector2(savedOffset.x, y);
        bgRenderer.material.mainTextureOffset = offset;
    }
}