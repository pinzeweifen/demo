using UnityEngine;
using UnityEditor;
using System;

public class QEditorLayout {

    static Rect rect;
    public static Rect Horizontal(Action<Rect> function, GUIStyle style,  params GUILayoutOption[] option)
    {
        rect = EditorGUILayout.BeginHorizontal(style, option);
        function.Invoke(rect);
        EditorGUILayout.EndHorizontal();
        return rect;
    }

    public static Rect Horizontal(Action<Rect> function, params GUILayoutOption[] option)
    {
        rect = EditorGUILayout.BeginHorizontal(option);
        function.Invoke(rect);
        EditorGUILayout.EndHorizontal();
        return rect;
    }

    public static Rect Vertical(Action<Rect> function, GUIStyle style,  params GUILayoutOption[] option)
    {
        rect = EditorGUILayout.BeginVertical(style, option);
        function.Invoke(rect);
        EditorGUILayout.BeginVertical();
        return rect;
    }

    public static Rect Vertical(Action<Rect> function, params GUILayoutOption[] option)
    {
        rect = EditorGUILayout.BeginVertical(option);
        function.Invoke(rect);
        EditorGUILayout.BeginVertical();
        return rect;
    }

    public static bool ToggleGroup(Action function,string label, bool toggle )
    {
        toggle = EditorGUILayout.BeginToggleGroup(label, toggle);
        function.Invoke();
        EditorGUILayout.EndToggleGroup();
        return toggle;
    }

    public static Vector2 ScrollView(Action function, Vector2 scrollPosition,  GUIStyle style, params GUILayoutOption[] option)
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, style, option);
        function.Invoke();
        EditorGUILayout.EndScrollView();
        return scrollPosition;
    }

    public static Vector2 ScrollView(Action function, Vector2 scrollPosition, params GUILayoutOption[] option)
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, option);
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
