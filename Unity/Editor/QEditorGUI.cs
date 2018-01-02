using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class QEditorGUI  {

    public enum StandardButton
    {
        None=0, OK=1, No=2, Cancel=4
    }

    static StandardButton b = StandardButton.None;
    /// <summary>
    /// 使用该函数前必须使用 BeginWindows 和 EndWindows 包裹才能显示
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="label"></param>
    /// <param name="fun"></param>
    /// <param name="isDrag"></param>
    /// <returns></returns>
    public static StandardButton MessageBox(Rect rect, string label, Action<Rect> fun, StandardButton button= StandardButton.OK | StandardButton.No, bool isDrag=true)
    {
        rect = GUILayout.Window(0, rect, id => {
            GUI.enabled = true;
            fun.Invoke(rect);
            GUILayout.FlexibleSpace();
            if (button == StandardButton.OK)
            {
                if (GUILayout.Button("Ok")) b = StandardButton.OK;
            }
            else if (button == StandardButton.No)
            {
                if (GUILayout.Button("No")) b = StandardButton.No;
            }
            else if (button == StandardButton.Cancel)
            {
                if (GUILayout.Button("Cancel")) b = StandardButton.Cancel;
            }
            else if (button == (StandardButton.OK | StandardButton.No))
            {
                QEditorLayout.Horizontal(e => {
                    if (GUILayout.Button("Ok")) b = StandardButton.OK;
                    if (GUILayout.Button("No")) b = StandardButton.No;
                });
            }
            else if(button == (StandardButton.OK| StandardButton.Cancel))
            {
                QEditorLayout.Horizontal(e => {
                    if (GUILayout.Button("Ok")) b = StandardButton.OK;
                    if (GUILayout.Button("Cancel")) b = StandardButton.Cancel;
                });
            }
            else if(button == (StandardButton.OK | StandardButton.No | StandardButton.Cancel))
            {
                QEditorLayout.Horizontal(e => {
                    if (GUILayout.Button("Ok")) b = StandardButton.OK;
                    if (GUILayout.Button("No")) b = StandardButton.No;
                    if (GUILayout.Button("Cancel")) b = StandardButton.Cancel;
                });
            }
            
            GUI.FocusWindow(id);
            GUI.BringWindowToFront(id);
            if(isDrag)
                GUI.DragWindow(new Rect(0, 0, 10000, 20));
            if (QEditorEvent.IsKeyDown())
            {
                if (QEditorEvent.GetKeyCode(KeyCode.Return))
                    b = StandardButton.OK;
                else if (QEditorEvent.GetKeyCode(KeyCode.Escape))
                    b = StandardButton.Cancel;
            }
        }, label);

        

        GUI.enabled = false;

        return b;
    }

    /// <summary>
    /// 初始化MessageBox返回值
    /// </summary>
    public static void InitMessageBox()
    {
        b = StandardButton.None;
    }

    private static Rect pathRect;
    public static string PathField(string label, string path, int width=0)
    {
        QEditorLayout.Horizontal(x => {

            EditorGUILayout.LabelField(label);

            if (width > 0)
                pathRect = new Rect(x.x + width, x.y, x.width - width, x.height);
            else
                pathRect = EditorGUILayout.GetControlRect();

            path = EditorGUI.TextField(pathRect, path);

            if (QEditorEvent.IsDragPerform(pathRect))
            {
                path = DragAndDrop.paths[0];
            }
        });
        return path;
    }

    public static int SpinBox(string label, int value, int minValue, int maxValue)
    {
        value = EditorGUILayout.IntField(label, value);
        if (value < minValue) value = minValue;
        else if (value > maxValue) value = maxValue;
        return value;
    }

    static float startWidth;
    static QTimeData timeData = new QTimeData();
    public static string TimerEditor(string label, string time)
    {
        if (timeData.SetHMS(time))
            timeData.Init();
        
        QEditorLayout.Horizontal(x => {
            EditorGUILayout.PrefixLabel(label);
            QEditorLayout.Horizontal(x2 => {
                startWidth = x2.width;
                x2.width = 15;
                #region 时
                if (QEditorEvent.IsScrollWhell(x2))
                    timeData.Hour += TimerEditorDalta();
                #endregion
                #region 分
                x2.x += 20;
                if (QEditorEvent.IsScrollWhell(x2))
                    timeData.Minute += TimerEditorDalta();
                #endregion
                #region 秒
                x2.x += 20;
                if (QEditorEvent.IsScrollWhell(x2))
                    timeData.Seconds += TimerEditorDalta();
                #endregion
                #region 毫秒
                x2.x += 18;
                x2.width = startWidth - 58;
                if (QEditorEvent.IsScrollWhell(x2))
                    timeData.Milliseconds += TimerEditorDalta();
                #endregion
                time = EditorGUILayout.TextField(timeData.ToString());
            });
        });
        if (timeData.SetHMS(time))
            time = timeData.ToString();
        return time;
    }

    private static int TimerEditorDalta()
    {
        return QEditorEvent.ScrollWhellDalta() ? 1 : -1;
    }
}


