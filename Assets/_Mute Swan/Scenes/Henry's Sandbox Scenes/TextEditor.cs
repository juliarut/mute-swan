using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextEditor : MonoBehaviour
{
    [Range(0.1f, 1f), SerializeField] private float widthToHeightRatio;
    [SerializeField] private float UpperCaseWidth;
    [SerializeField] private float UpperCaseHeight;
    [SerializeField] private float lowerCaseWidth;
    [SerializeField] private float lowerCaseHeight;
    [SerializeField] private float spaceWidth;
    [SerializeField] private float depth;
    [SerializeField] private float charSpacing;
    [SerializeField] private Color fontColor;

    private List<char> charList;
    private TextInfo textInfo;

    [SerializeField] private string title;
    [Multiline, SerializeField] private string lyricText;

    private Vector3 startPos;

    public void SetDefaultValues()
    {
        widthToHeightRatio = 0.95f;
        UpperCaseHeight = 0.5f;
        UpperCaseWidth = UpperCaseHeight * widthToHeightRatio;
        lowerCaseHeight = 0.4f;
        lowerCaseWidth = lowerCaseHeight * widthToHeightRatio;
        spaceWidth = 0.06f;
        depth = 0.02f;
        charSpacing = 0.05f;
        fontColor = Color.yellow;
    }

    public void SetToNewWidthToHeightRatio()
    {
        UpperCaseWidth = UpperCaseHeight * widthToHeightRatio;
        lowerCaseWidth = lowerCaseHeight * widthToHeightRatio;
    }

    public void CreateTextLineObject()
    {
        GameObject newText = new();
        TextMeshPro textMesh = newText.AddComponent<TextMeshPro>();
        RectTransform textRectTransform = newText.GetComponent<RectTransform>();
        textRectTransform.localPosition = startPos;
        textMesh.text = lyricText;

        //textMeshPro.rectTransform.position = startPos;
        textInfo = gameObject.GetComponent<TextInfo>();
        List<char> tempCharList = new List<char>();
        startPos = transform.position;
        GameObject newLineParent = new GameObject();
        newLineParent.AddComponent<TextInfo>();
        newLineParent.transform.position = startPos;
        newLineParent.name = title;
        newLineParent.transform.parent = transform;
        float totalWidth = 0;

        foreach(char c in lyricText)
        {
            float rectTransformZOffset = 0.005f;

            if (char.IsUpper(c))
            {
                GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newCube.transform.position = startPos;
                newCube.transform.localScale = new Vector3(UpperCaseWidth, UpperCaseHeight, depth);
                newCube.transform.parent = newLineParent.transform;
                newCube.name = c.ToString();
                newCube.GetComponent<MeshRenderer>().sharedMaterial.color = fontColor;
                Canvas newCanvas = AddCanvas(rectTransformZOffset, newCube);
                GameObject tmpUgui = new GameObject("Text (TMP)");
                tmpUgui.transform.position = transform.position;
                tmpUgui.transform.parent = newCanvas.transform;
                tmpUgui.AddComponent<TextMeshProUGUI>();
                RectTransform tmpRectTransfrom = tmpUgui.GetComponent<RectTransform>();
                tmpRectTransfrom.sizeDelta = new Vector2(1, 1);
                tmpRectTransfrom.localScale = new Vector3(1f, 1f, 1f);
                tmpRectTransfrom.position -= new Vector3(0f, 0f, (depth / 2) + rectTransformZOffset);
                tmpRectTransfrom.anchorMin = new Vector2(0f, 0f);
                tmpRectTransfrom.anchorMax = new Vector2(1f, 1f);
                tmpRectTransfrom.offsetMax = new Vector2(0f, 0f);
                tmpRectTransfrom.offsetMin = new Vector2(0f, 0f);
                totalWidth += newCube.transform.localScale.x;
            }
            else if (char.IsLower(c))
            {
                GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newCube.transform.position = startPos;
                newCube.transform.localScale = new Vector3(lowerCaseWidth, lowerCaseHeight, depth);
                newCube.transform.parent = newLineParent.transform;
                newCube.name = c.ToString();
                newCube.GetComponent<MeshRenderer>().sharedMaterial.color = fontColor;
                totalWidth += newCube.transform.localScale.x;
            } 
            else if (char.IsSeparator(' ')) 
            {
                GameObject emptySpaceObject = new GameObject("space");
                emptySpaceObject.transform.position = startPos;
                emptySpaceObject.transform.localScale = new Vector3(spaceWidth, UpperCaseHeight, depth);
                emptySpaceObject.transform.parent = newLineParent.transform;
                totalWidth += spaceWidth;
            }

            if (charList.IndexOf(c) == -1 && char.IsLetterOrDigit(c))
            {
                charList.Add(c);
            }

            if (tempCharList.IndexOf(c) == -1 && char.IsLetterOrDigit(c))
            {
                tempCharList.Add(c);
            }
        }

        int countofChars = 0;

        foreach (char ch in lyricText)
        {
            if (char.IsLetterOrDigit(ch))
            {
                countofChars++;
            }
        }

        totalWidth += ((countofChars - 1) * charSpacing);
        PositionCube(totalWidth, newLineParent, lyricText);
        charList.Sort();
        textInfo.UpdateCharList(charList);
        tempCharList.Sort();
        newLineParent.GetComponent<TextInfo>().UpdateCharList(tempCharList);
    }

    private Canvas AddCanvas(float rectTransformOffset, GameObject newCube)
    {
        GameObject letterCanvas = new GameObject("Canvas");
        letterCanvas.transform.position = startPos;
        letterCanvas.transform.parent = newCube.transform;
        Canvas newCanvas = letterCanvas.AddComponent<Canvas>();
        RectTransform rectTransform = newCanvas.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(1f, 1f);
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
        rectTransform.position -= new Vector3(0f, 0f, (depth / 2) + rectTransformOffset);
        newCanvas.renderMode = RenderMode.WorldSpace;
        return newCanvas;
    }

    private void PositionCube(float totalWidth, GameObject newLineParent, string lyricText)
    {
        // 1. Set first object to total width / 2 to the left
        // 2. Subsequent objects go to the right of previous object by previous object's with + charSpacing.

        GameObject currentObject = null;
        GameObject previousObject = null;

        for (int i = 0; i < lyricText.Length; i++)
        {
            float currentObjectWidth = 0;
            float currentObjectHeight = 0;

            if (i == 0)
            {
                currentObject = newLineParent.transform.GetChild(i).gameObject;
                currentObjectWidth = currentObject.transform.localScale.x;
                currentObjectHeight = currentObject.transform.localScale.y;

                if (currentObjectHeight == UpperCaseHeight)
                {
                    currentObject.transform.position -= new Vector3((totalWidth / 2f) - (currentObjectWidth / 2), 0f, 0f);
                }
                else
                {
                    currentObject.transform.position -= new Vector3((totalWidth / 2f) - (currentObjectWidth / 2), (UpperCaseHeight - currentObjectHeight) / 2, 0f);
                }
                
            }
            else
            {
                currentObject = newLineParent.transform.GetChild(i).gameObject;
                previousObject = newLineParent.transform.GetChild(i - 1).gameObject;
                float previousObjectWidth = previousObject.transform.localScale.x;
                float previousObjectHeight = previousObject.transform.localScale.y;
                currentObjectWidth = currentObject.transform.localScale.x;
                currentObjectHeight = currentObject.transform.localScale.y;

                currentObject.transform.position += new Vector3(previousObject.transform.position.x + (previousObjectWidth / 2) + charSpacing + (currentObjectWidth / 2), 0f, 0f);

                if (currentObjectHeight < previousObjectHeight)
                {
                    currentObject.transform.position = new Vector3(currentObject.transform.position.x, currentObject.transform.position.y - ((previousObjectHeight - currentObjectHeight) / 2f), currentObject.transform.position.z);
                }
                else if (currentObjectWidth == previousObjectWidth)
                {
                    currentObject.transform.position = new Vector3(currentObject.transform.position.x, previousObject.transform.position.y, currentObject.transform.position.z);
                }
            }
        }
    }

    public void ClearCharList()
    {
        charList.Clear();
    }

    public void ClearEntries()
    {
        foreach (Transform transform in gameObject.transform)
        {
            if (transform.gameObject.name != "Cursor")
            {
                DestroyImmediate(transform.gameObject);
            }
        }

        foreach (Transform transform in gameObject.transform)
        {
            if (transform.gameObject.name != "Cursor")
            {
                DestroyImmediate(transform.gameObject);
            }
        }

        GetComponent<TextInfo>().ClearCharList();
    }

    public void ClearTextBoxes()
    {
        title = "";
        lyricText = "";
    }

}
