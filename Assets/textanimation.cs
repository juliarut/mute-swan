using UnityEngine;
using TMPro;
using System.Collections;

public class TextAnimation : MonoBehaviour
{
    public TMP_Text animatedText;
    public float revealSpeed = 0.05f;

    void Start()
    {
        // Run the animation when the scene starts (you can remove this if not needed)
        AnimateText();
    }

    // Custom method to start text animation
    public void StartTextAnimation()
    {
        AnimateText();
    }

    void AnimateText()
    {
        animatedText.text = "";
        StartCoroutine(RevealTextCoroutine());
    }

    IEnumerator RevealTextCoroutine()
    {
        for (int i = 0; i < animatedText.text.Length; i++)
        {
            animatedText.text += animatedText.text[i];
            yield return new WaitForSeconds(revealSpeed);
        }
    }
}
