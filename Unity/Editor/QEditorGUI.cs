using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QEditorGUI  {

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
    static QDataTimer dataTimer = new QDataTimer();
    public static string TimerEditor(string label, string timer)
    {
        dataTimer.SetHMS(timer);
        
        QEditorLayout.Horizontal(x => {
            EditorGUILayout.PrefixLabel(label);
            QEditorLayout.Horizontal(x2 => {
                startWidth = x2.width;
                x2.width = 15;
                #region 时
                if (QEditorEvent.IsScrollWhell(x2))
                    dataTimer.Hour++;
                #endregion
                #region 分
                x2.x += 20;
                if (QEditorEvent.IsScrollWhell(x2))
                    dataTimer.Minute++;
                #endregion
                #region 秒
                x2.x += 20;
                if (QEditorEvent.IsScrollWhell(x2))
                    dataTimer.Seconds++;
                #endregion
                #region 毫秒
                x2.x += 18;
                x2.width = startWidth - 58;
                if (QEditorEvent.IsScrollWhell(x2))
                    dataTimer.Milliseconds++;
                #endregion
                timer = EditorGUILayout.TextField(dataTimer.ToString());
            });
        });
        if (dataTimer.SetHMS(timer))
        {
            timer = dataTimer.ToString();
        }
        return timer;
    }
}


