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
    [SerializeField] private float depth;
    [SerializeField] private float charSpacing;
    [SerializeField] private Color fontColor;
    
    [SerializeField] private string title;
    [Multiline, SerializeField] private string lyricText;

    private Vector3 startPos;

    public void CreateTextLineObject()
    {
        startPos = transform.position;
        GameObject newLineParent = new GameObject();
        newLineParent.name = title;
        newLineParent.transform.parent = transform;

        foreach(char c in lyricText)
        {
            if (char.IsUpper(c))
            {
                GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newCube.transform.localScale = new Vector3(UpperCaseWidth, UpperCaseHeight, depth);
                newCube.transform.parent = newLineParent.transform;
                newCube.name = c.ToString();
                newCube.GetComponent<MeshRenderer>().sharedMaterial.color = fontColor;
                PositionCube(c, lyricText, UpperCaseWidth, newCube, newLineParent);
            }
            else if (char.IsLower(c))
            {
                GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newCube.transform.localScale = new Vector3(lowerCaseWidth, lowerCaseHeight, depth);
                newCube.transform.parent = newLineParent.transform;
                newCube.name = c.ToString();
                newCube.GetComponent<MeshRenderer>().sharedMaterial.color = fontColor;
                PositionCube(c, lyricText, lowerCaseWidth, newCube, newLineParent);
            }
            
        }
    }

    private void PositionCube(char c, string lyricText, float width, GameObject newCube, GameObject newLineParent)
    {
        // 1. Position first char at transform position
        // 2. Move current char - 1 0.5*width+charSpacing/2 left
        // 3. Move current char to current char - 1 + width + spacing to the right

        for (int i = 0; i <= lyricText.IndexOf(c); i++)
        {
            if (lyricText.IndexOf(c) == 0)
            {
                newCube.transform.position = transform.position;
                return;
            }
            else if (i > 0)
            {
                Vector3 offset = new Vector3(((width / 2 + charSpacing) / 2), 0, 0);
                Vector3 previousCharPosition = newLineParent.transform.GetChild(i - 1).transform.position;
                newLineParent.transform.GetChild(i-1).transform.position -= offset;
                newLineParent.transform.GetChild(i).transform.position = previousCharPosition + offset;
            }
        }
    }
}
