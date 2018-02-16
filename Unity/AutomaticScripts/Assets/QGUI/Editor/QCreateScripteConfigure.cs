using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace QGUI
{
    public class QCreateScripteConfigure : EditorWindow
    {
        public static string uiPath = "Scripts/UI";
        public static string notUIPath = "Scripts/NotUI";
        public static string resourceFile = "QGUI/Resources/Text/Template.txt";

        [MenuItem("QGUI/CreateScript")]
        private static void Init()
        {
            GetWindow<QCreateScripteConfigure>().Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical("box");
            {
                uiPath = EditorGUILayout.TextField("UI路径", uiPath);
                EditorGUILayout.Space();
                notUIPath = EditorGUILayout.TextField("非UI路径", notUIPath);
                EditorGUILayout.Space();
                resourceFile = EditorGUILayout.TextField("预设文本路径", resourceFile);
            }
            EditorGUILayout.EndVertical();
            
            if (GUILayout.Button("Repaint"))
            {
                if (!Directory.Exists("Assets/" + notUIPath))
                {
                    Directory.CreateDirectory("Assets/" + notUIPath);
                }
                if (!Directory.Exists("Assets/" + uiPath))
                {
                    Directory.CreateDirectory("Assets/" + uiPath);
                }
            }
        }
    }
}
