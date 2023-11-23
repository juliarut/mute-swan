using System.Collections;
using TMPro;
using UnityEngine;

public class UiFade : MonoBehaviour
{
    public TMP_Text[] textMeshProTexts; 
    public float fadeDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // För att försäkra oss om att texten är synlig från början
        SetAlphaForAll(1f);
    }

    // Metod för att starta fade-effekten på alla TextMeshPro-objekt
    public void StartFadeForAll()
    {
        // Starta en korutin för fade för varje TextMeshPro-objekt
        foreach (TMP_Text textMeshProText in textMeshProTexts)
        {
            StartCoroutine(FadeText(textMeshProText.color.a, 0f, fadeDuration, textMeshProText));
        }
    }

    // Metod för att stoppa fade-effekten på alla TextMeshPro-objekt
    public void StopFadeForAll()
    {
        // Starta en korutin för fade för varje TextMeshPro-objekt
        foreach (TMP_Text textMeshProText in textMeshProTexts)
        {
            StartCoroutine(FadeText(textMeshProText.color.a, 1f, fadeDuration, textMeshProText));
        }
    }

    // Korutin för fade-effekten på en enskild TextMeshPro-objekt
    IEnumerator FadeText(float startAlpha, float targetAlpha, float duration, TMP_Text textMeshProText)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Använd Lerp för att få ett smidigt övergångsvärde mellan startAlpha och targetAlpha
            SetAlpha(textMeshProText, Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration));

            elapsedTime += Time.deltaTime;

            yield return null; // Vänta på nästa frame
        }

        // Se till att slutvärdet är exakt när övergången är klar
        SetAlpha(textMeshProText, targetAlpha);
    }

    // Hjälpmetod för att ställa in alpha-värdet på en enskild TMP-text
    void SetAlpha(TMP_Text textMeshProText, float alpha)
    {
        Color color = textMeshProText.color;
        color.a = alpha;
        textMeshProText.color = color;
    }

    // Hjälpmetod för att ställa in alpha-värdet på alla TMP-texter
    void SetAlphaForAll(float alpha)
    {
        foreach (TMP_Text textMeshProText in textMeshProTexts)
        {
            SetAlpha(textMeshProText, alpha);
        }
    }
}
