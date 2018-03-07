using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace QGUI
{
    public class QCreateScriptsConfigure : EditorWindow
    {
        public static string uiPath = "Assets/Scripts/UI";
        public static string notUIPath = "Assets/Scripts/NotUI";
        public static string resourceFile = "Assets/QGUI/Resources/Text/Template.txt";

        private GUIContent isShowStr = new GUIContent("IsShowConfigure","是否在Scene和Hierarchy显示快捷窗口");
        private GUIContent uiPathStr = new GUIContent("UI Path","UI文件创建路径");
        private GUIContent notPathStr = new GUIContent("NotUI Path","非UI文件创建路径");
        private GUIContent textPathStr = new GUIContent("Default text path","默认文本路径");

        private bool IsEnabledUI = false;
        private bool IsEnabledNotUI = false;
        private bool IsEnabledText = true;

        [MenuItem("QGUI/CreateScript")]
        private static void Init()
        {
            GetWindow<QCreateScriptsConfigure>("Configure").Show();
        }
        string tmp;
        private void OnGUI()
        {
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical("box");
            {
                QCreateScript.isShow = EditorGUILayout.ToggleLeft(isShowStr, QCreateScript.isShow);
                EditorGUILayout.Space();

                uiPath = DragTextField(uiPathStr,uiPath,ref IsEnabledUI);

                notUIPath = DragTextField(notPathStr,notUIPath,ref IsEnabledNotUI);

                resourceFile = DragTextField(textPathStr,resourceFile,ref IsEnabledText);
            }
            EditorGUILayout.EndVertical();

            DrawRepaintButton();
        }

        private string DragTextField(GUIContent label,string value, ref bool isShow)
        {
            EditorGUILayout.BeginHorizontal();
            {
                isShow = EditorGUILayout.ToggleLeft(label,isShow, GUILayout.MaxWidth(120));
                var rect = EditorGUILayout.GetControlRect();
                if (isShow)
                {
                    value = EditorGUI.TextField(rect, value);
                    if (Event.current.IsDragPerform(rect))
                    {
                        Event.current.Use();
                        return DragAndDrop.paths[0];
                    }
                }
                else
                {
                    EditorGUI.LabelField(rect, value);
                }
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
            return value;
        }

        private void DrawRepaintButton()
        {
            if (GUILayout.Button("Repaint"))
            {
                if (!Directory.Exists(notUIPath))
                    Directory.CreateDirectory(notUIPath);

                if (!Directory.Exists(uiPath))
                    Directory.CreateDirectory(uiPath);
            }
        }
    }
}
