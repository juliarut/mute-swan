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

        if (GUILayout.Button("Create New Line Object"))
        {
            editor.CreateTextLineObject();
        }
    }
}
