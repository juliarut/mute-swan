using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

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

    [SerializeField] private string title;
    [Multiline, SerializeField] private string lyricText;

    private Vector3 startPos;

    public void SetDefaultValues()
    {
        widthToHeightRatio = 0.5f;
        UpperCaseHeight = 0.1f;
        UpperCaseWidth = UpperCaseHeight * widthToHeightRatio;
        lowerCaseHeight = 0.07f;
        lowerCaseWidth = lowerCaseHeight * widthToHeightRatio;
        spaceWidth = 0.5f;
        depth = 0.02f;
        charSpacing = 0.01f;
        fontColor = Color.yellow;
    }

    public void SetToNewWidthToHeightRatio()
    {
        UpperCaseWidth = UpperCaseHeight * widthToHeightRatio;
        lowerCaseWidth = lowerCaseHeight * widthToHeightRatio;
    }

    public void CreateTextLineObject()
    {
        startPos = transform.position;
        GameObject newLineParent = new GameObject();
        newLineParent.name = title;
        newLineParent.transform.parent = transform;
        float totalWidth = 0;

        foreach(char c in lyricText)
        {
            if (char.IsUpper(c))
            {
                GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newCube.transform.localScale = new Vector3(UpperCaseWidth, UpperCaseHeight, depth);
                newCube.transform.parent = newLineParent.transform;
                newCube.name = c.ToString();
                newCube.GetComponent<MeshRenderer>().sharedMaterial.color = fontColor;
                totalWidth += newCube.transform.localScale.x;
            }
            else if (char.IsLower(c))
            {
                GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newCube.transform.localScale = new Vector3(lowerCaseWidth, lowerCaseHeight, depth);
                newCube.transform.parent = newLineParent.transform;
                newCube.name = c.ToString();
                newCube.GetComponent<MeshRenderer>().sharedMaterial.color = fontColor;
                totalWidth += newCube.transform.localScale.x;
            } else if (char.IsSeparator(' ')) 
            {
                totalWidth += spaceWidth;
            }
        }
        PositionCube(totalWidth, newLineParent, lyricText);
    }

    private void PositionCube(float totalWidth, GameObject newLineParent, string lyricText)
    {
        // 1. Set first object to total width / 2 to the left
        // 2. Subsequent objects go to the right of previous object by previous object's with + charSpacing.

        GameObject currentObject = null;
        GameObject previousObject = null;

        for (int i = 0; i < lyricText.Length; i++)
        {
            if (i == 0)
            {
                currentObject = newLineParent.transform.GetChild(i).gameObject;
                currentObject.transform.position += new Vector3(transform.position.x - (totalWidth / 2f), 0f, 0f);
            }
            else
            {
                currentObject = newLineParent.transform.GetChild(i).gameObject;
                previousObject = newLineParent.transform.GetChild(i - 1).gameObject;
                float previousObjectWidth = previousObject.transform.localScale.x;
                float previousObjectHeight = previousObject.transform.localScale.y;
                float currentObjectWidth = currentObject.transform.localScale.x;
                float currentObjectHeight = currentObject.transform.localScale.y;

                currentObject.transform.position = new Vector3(previousObject.transform.position.x + (previousObjectWidth / 2) + charSpacing + (currentObjectWidth / 2), 0f, 0f);

                if (currentObjectHeight < previousObjectHeight)
                {
                    currentObject.transform.position = new Vector3(currentObject.transform.position.x, currentObject.transform.position.y - ((previousObjectHeight - currentObjectHeight) / 2f), 0f);
                } else if (currentObjectWidth == previousObjectWidth)
                {
                    currentObject.transform.position = new Vector3(currentObject.transform.position.x, previousObject.transform.position.y, 0f);
                }
            }
        }
    }
}
