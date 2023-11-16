using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextEditor : MonoBehaviour
{
    [SerializeField] private Color fontColor;
    [SerializeField] private float fontSize;
    [SerializeField] private TMP_FontAsset fontAsset;

    private Vector3 startPos;
    private Dictionary<string, string> lyricDictionary;

    public void CreateTextLineObject()
    {
        lyricDictionary = GetComponent<Lyrics>().GetLyricDictionary();

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
            textMeshPro.color = Color.white;
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

        //foreach(char c in lyricText)
        //{
        //    GameObject newTextMeshProObject = new GameObject();
        //    newTextMeshProObject.transform.position = startPos;
        //    TextMeshPro newTextMeshPro = newTextMeshProObject.AddComponent<TextMeshPro>();
        //    newTextMeshProObject.transform.SetParent(newText.transform);
        //    newTextMeshProObject.name = c.ToString();
        //    newTextMeshPro.fontSize = fontSize;
        //    newTextMeshPro.color = fontColor;
        //    newTextMeshPro.text = c.ToString();
        //    newTextMeshPro.alignment = TextAlignmentOptions.Center;
        //    newTextMeshPro.horizontalAlignment = HorizontalAlignmentOptions.Center;
        //    newTextMeshPro.verticalAlignment = VerticalAlignmentOptions.Middle;
        //    ContentSizeFitter newContentSizeFitter = newTextMeshProObject.AddComponent<ContentSizeFitter>();
        //    newContentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        //    newContentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        //    TMP_TextInfo newTmp_Info = newTextMeshPro.textInfo;
        //    newTmp_Info.characterInfo[0].origin = tmp_textInfo.characterInfo[0].origin;


        //}
    }

    public void ClearEntries()
    {


        //for (int i = gameObject.transform.childCount - 1; i <= 0; i--)
        //{
        //    Debug.Log(gameObject.transform.GetChild(i).gameObject.name);

        //    //GameObject lyricElement = gameObject.transform.GetChild(i).gam;
        //    if (gameObject.transform.GetChild(i).gameObject.name != "Cursor")
        //    {
        //        Destroy(gameObject.transform.GetChild(i).gameObject);
        //    }
        //}

        foreach (Transform transform in gameObject.transform)
        {
            if (transform.gameObject.name != "Cursor")
            {
                DestroyImmediate(transform.gameObject);
            }
        }

    }

}
