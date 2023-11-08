using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.ComponentModel;

[CustomEditor(typeof(TextEditor))]
public class TextEditorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TextEditor editor = target as TextEditor;

        if (GUILayout.Button("Set Default Values"))
        {
            editor.SetDefaultValues();
        }
        else if (GUILayout.Button("Adjust to new width to height ratio"))
        {
            editor.SetToNewWidthToHeightRatio();
        }
        else if (GUILayout.Button("Create New Line Object"))
        {
            editor.CreateTextLineObject();
        }
        else if (GUILayout.Button("Clear char list"))
        {
            editor.ClearCharList();
        }
        else if (GUILayout.Button("Clear entries"))
        {
            editor.ClearEntries();
        }
        else if (GUILayout.Button("Clear Text Boxes"))
        {
            editor.ClearTextBoxes();
        }

        
    }
}
