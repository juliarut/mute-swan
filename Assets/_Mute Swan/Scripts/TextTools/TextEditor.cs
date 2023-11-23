using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextEditor : MonoBehaviour
{
    // Member variables
    [SerializeField] private Color fontColor;
    [SerializeField] private float fontSize;
    [SerializeField] private TMP_FontAsset fontAsset;

    private Vector3 startPos;
    private Dictionary<string, string> lyricDictionary;

    /// <summary>
    /// Create new text objects
    /// </summary>
    public void CreateTextLineObject()
    {
        // Get dictionary
        lyricDictionary = GetComponent<Lyrics>().GetLyricDictionary();

        // Run through each description in dictionary and create new TMP object
        foreach (string description in lyricDictionary.Keys)
        {
            startPos = transform.position;
            GameObject newText = new();
            newText.transform.position = startPos;
            newText.transform.parent = transform;
            newText.name = description;
            TextMeshPro textMeshPro = newText.AddComponent<TextMeshPro>();
            RectTransform textRectTransform = newText.GetComponent<RectTransform>();
            textMeshPro.font = fontAsset;
            textMeshPro.text = lyricDictionary[description];
            textMeshPro.color = fontColor;
            textMeshPro.fontSize = fontSize;
            textMeshPro.alignment = TextAlignmentOptions.Center;
            textMeshPro.horizontalAlignment = HorizontalAlignmentOptions.Center;
            textMeshPro.verticalAlignment = VerticalAlignmentOptions.Middle;
            ContentSizeFitter textSizeFitter = newText.AddComponent<ContentSizeFitter>();
            textSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            textSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            TMP_TextInfo tmp_textInfo = textMeshPro.textInfo;
            newText.SetActive(false);
        }
    }
    /// <summary>
    /// Clear child entries
    /// </summary>
    public void ClearEntries()
    {
        foreach (Transform transform in gameObject.transform)
        {
            if (transform.gameObject.name != "Cursor")
            {
                DestroyImmediate(transform.gameObject);
            }
        }

    }

}
