using System.Collections;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    private TMP_Text textMeshPro;
    public float totalTypingTime = 5f; // Total tid för typning i sekunder

    private string fullText;

    private void Start()
    {
        // Hämta referensen till TextMeshPro-komponenten på detta objekt
        textMeshPro = GetComponent<TMP_Text>();

        // Spara den ursprungliga texten för senare användning
        fullText = textMeshPro.text;

        // Rensa texten för att förbereda för typning
        textMeshPro.text = string.Empty;

        // Beräkna typningshastigheten baserat på den totala tiden och antalet bokstäver
        float typingSpeed = CalculateTypingSpeed(totalTypingTime, fullText.Length);

        // Starta typningseffekten
        StartCoroutine(TypeText(typingSpeed));
    }

    // Metod för att beräkna typningshastigheten baserat på den totala tiden och antalet bokstäver
    private float CalculateTypingSpeed(float totalTypingTime, int totalLetters)
    {
        // Beräkna typningshastigheten baserat på formeln
        return totalTypingTime / totalLetters;
    }

    // Coroutine för att simulera typningseffekten
    IEnumerator TypeText(float typingSpeed)
    {
        // Iterera genom varje bokstav i texten
        foreach (char letter in fullText)
        {
            // Lägg till varje bokstav till texten
            textMeshPro.text += letter;

            // Vänta den specificerade tiden innan nästa bokstav
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
