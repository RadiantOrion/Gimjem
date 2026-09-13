using UnityEngine;
using System.Collections;

public class FallDown : MonoBehaviour
{
    public RectTransform target;      // drag Image RectTransform di sini
    public float fallDistance = 800f; // seberapa jauh jatuh (dalam unit UI)
    public float duration = 1f;       // lama animasi (detik)
    public bool useEase = true;       // pakai easing biar natural

    private Vector2 startPos;

    void Awake()
    {
        if (target == null) target = GetComponent<RectTransform>();
        startPos = target.anchoredPosition;
    }

    public void PlayFall()
    {
        StopAllCoroutines();
        StartCoroutine(FallRoutine());
    }

    private IEnumerator FallRoutine()
    {
        Vector2 endPos = startPos + Vector2.down * fallDistance;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float progress = t / duration;

            if (useEase)
                progress = 1f - Mathf.Pow(1f - progress, 3f); // ease-out cubic

            target.anchoredPosition = Vector2.Lerp(startPos, endPos, progress);
            yield return null;
        }

        target.anchoredPosition = endPos;
    }
}