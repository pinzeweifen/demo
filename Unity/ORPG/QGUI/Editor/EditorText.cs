using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using QGUI;
public class EditorText : EditorWindow 
{
    [MenuItem("Tool/To")]
    static void Init()
    {
        GetWindow<EditorText>().Show();
    }

    string value;
    private void OnGUI()
    {
        var rect = EditorGUILayout.GetControlRect();
        value = EditorGUI.TextField(rect, "aa", value);
        if (Event.current.IsDragPerform(rect))
        {
            value = DragAndDrop.paths[0];
        }
    }
}