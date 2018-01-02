using UnityEngine;
using UnityEditor;
using System;

public class QEditorLayout {

    static Rect rect;
    public static Rect Horizontal(Action<Rect> function, GUIStyle style,  params GUILayoutOption[] options)
    {
        rect = EditorGUILayout.BeginHorizontal(style, options);
        function.Invoke(rect);
        EditorGUILayout.EndHorizontal();
        return rect;
    }

    public static Rect Horizontal(Action<Rect> function, params GUILayoutOption[] options)
    {
        rect = EditorGUILayout.BeginHorizontal(options);
        function.Invoke(rect);
        EditorGUILayout.EndHorizontal();
        return rect;
    }

    public static Rect Vertical(Action<Rect> function, GUIStyle style,  params GUILayoutOption[] options)
    {
        rect = EditorGUILayout.BeginVertical(style, options);
        function.Invoke(rect);
        EditorGUILayout.EndVertical();
        return rect;
    }

    public static Rect Vertical(Action<Rect> function, params GUILayoutOption[] options)
    {
        rect = EditorGUILayout.BeginVertical(options);
        function.Invoke(rect);
        EditorGUILayout.EndVertical();
        return rect;
    }

    public static bool ToggleGroup(Action function,string label, bool toggle )
    {
        toggle = EditorGUILayout.BeginToggleGroup(label, toggle);
        function.Invoke();
        EditorGUILayout.EndToggleGroup();
        return toggle;
    }

    public static Vector2 ScrollView(Action function, Vector2 scrollPosition,  GUIStyle style, params GUILayoutOption[] options)
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, style, options);
        function.Invoke();
        EditorGUILayout.EndScrollView();
        return scrollPosition;
    }

    public static Vector2 ScrollView(Action function, Vector2 scrollPosition, params GUILayoutOption[] options)
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, options);
        function.Invoke();
        EditorGUILayout.EndScrollView();
        return scrollPosition;
    }

    private static bool isFadeGroup;
    public static bool FadeGroup(Action function, float value)
    {
        isFadeGroup = EditorGUILayout.BeginFadeGroup(value);
        function.Invoke();
        EditorGUILayout.EndFadeGroup();
        return isFadeGroup;
    }

}
