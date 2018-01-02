using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QLayout : MonoBehaviour {

    public static void Horizontal(Action function, params GUILayoutOption[] options)
    {
        GUILayout.BeginHorizontal(options);
        function.Invoke();
        GUILayout.EndHorizontal();
    }

    public static void Horizontal(Action function, GUIStyle style, params GUILayoutOption[] options)
    {
        GUILayout.BeginHorizontal(style,options);
        function.Invoke();
        GUILayout.EndHorizontal();
    }

    public static void Horizontal(Action function, Texture image, GUIStyle style, params GUILayoutOption[] options)
    {
        GUILayout.BeginHorizontal(image,style,options);
        function.Invoke();
        GUILayout.EndHorizontal();
    }

    public static void Horizontal(Action function, string label, GUIStyle style, params GUILayoutOption[] options)
    {
        GUILayout.BeginHorizontal(label, style, options);
        function.Invoke();
        GUILayout.EndHorizontal();
    }

    public static void Horizontal(Action function, GUIContent content, GUIStyle style, params GUILayoutOption[] options)
    {
        GUILayout.BeginHorizontal(content, style, options);
        function.Invoke();
        GUILayout.EndHorizontal();
    }

    public static void Vertical(Action function, params GUILayoutOption[] options)
    {
        GUILayout.BeginVertical(options);
        function.Invoke();
        GUILayout.EndVertical();
    }

    public static void Vertical(Action function, GUIStyle style, params GUILayoutOption[] options)
    {
        GUILayout.BeginVertical(style, options);
        function.Invoke();
        GUILayout.EndVertical();
    }

    public static void Vertical(Action function, Texture image, GUIStyle style, params GUILayoutOption[] options)
    {
        GUILayout.BeginVertical(image, style, options);
        function.Invoke();
        GUILayout.EndVertical();
    }

    public static void Vertical(Action function, string label, GUIStyle style, params GUILayoutOption[] options)
    {
        GUILayout.BeginVertical(label, style, options);
        function.Invoke();
        GUILayout.EndVertical();
    }

    public static void Vertical(Action function, GUIContent content, GUIStyle style, params GUILayoutOption[] options)
    {
        GUILayout.BeginVertical(content, style, options);
        function.Invoke();
        GUILayout.EndVertical();
    }

    public static Vector2 ScrollView(Action function, Vector2 scrollPosition, GUIStyle style)
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, style);
        function.Invoke();
        GUILayout.EndScrollView();
        return scrollPosition;
    }

    public static Vector2 ScrollView(Action function, Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options)
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, options);
        function.Invoke();
        GUILayout.EndScrollView();
        return scrollPosition;
    }

    public static Vector2 ScrollView(Action function, Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options)
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, options);
        function.Invoke();
        GUILayout.EndScrollView();
        return scrollPosition;
    }

    public static Vector2 ScrollView(Action function, Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options)
    {
        scrollPosition = GUILayout.BeginScrollView( scrollPosition,  alwaysShowHorizontal,  alwaysShowVertical,  horizontalScrollbar,  verticalScrollbar,  background, options);
        function.Invoke();
        GUILayout.EndScrollView();
        return scrollPosition;
    }

    public static Vector2 ScrollView(Action function, Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options)
    {
        scrollPosition = GUILayout.BeginScrollView( scrollPosition, horizontalScrollbar, verticalScrollbar, options);
        function.Invoke();
        GUILayout.EndScrollView();
        return scrollPosition;
    }

    public static Vector2 ScrollView(Action function, Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options)
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, style, options);
        function.Invoke();
        GUILayout.EndScrollView();
        return scrollPosition;
    }

    public static Vector2 ScrollView(Action function, Vector2 scrollPosition,params GUILayoutOption[] options)
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition,options);
        function.Invoke();
        GUILayout.EndScrollView();
        return scrollPosition;
    }

    public static void Area(Action function, Rect rect)
    {
        GUILayout.BeginArea(rect);
        function.Invoke();
        GUILayout.EndArea();
    }

    public static void Area(Action function, Rect rect, GUIContent content)
    {
        GUILayout.BeginArea(rect,content);
        function.Invoke();
        GUILayout.EndArea();
    }

    public static void Area(Action function, Rect rect, GUIStyle style)
    {
        GUILayout.BeginArea(rect,style);
        function.Invoke();
        GUILayout.EndArea();
    }

    public static void Area(Action function, Rect rect, string text)
    {
        GUILayout.BeginArea(rect,text);
        function.Invoke();
        GUILayout.EndArea();
    }

    public static void Area(Action function, Rect rect, Texture image)
    {
        GUILayout.BeginArea(rect,image);
        function.Invoke();
        GUILayout.EndArea();
    }

    public static void Area(Action function, Rect rect, GUIContent content, GUIStyle style)
    {
        GUILayout.BeginArea(rect,content, style);
        function.Invoke();
        GUILayout.EndArea();
    }

    public static void Area(Action function, Rect rect, string text, GUIStyle style)
    {
        GUILayout.BeginArea(rect,text,style);
        function.Invoke();
        GUILayout.EndArea();
    }

    public static void Area(Action function, Rect rect, Texture image, GUIStyle style)
    {
        GUILayout.BeginArea(rect,image,style);
        function.Invoke();
        GUILayout.EndArea();
    }
}
