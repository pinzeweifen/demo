using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace QGUI
{
    public class QCreateScriptsConfigure : EditorWindow
    {
        public static string uiPath = "Scripts/UI";
        public static string notUIPath = "Scripts/NotUI";
        public static string resourceFile = "QGUI/Resources/Text/Template.txt";

        [MenuItem("QGUI/CreateScript")]
        private static void Init()
        {
            GetWindow<QCreateScriptsConfigure>("Configure").Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical("box");
            {
                QCreateScript.isShow = EditorGUILayout.ToggleLeft("IsShowConfigure", QCreateScript.isShow);
                EditorGUILayout.Space();
                uiPath = EditorGUILayout.TextField("UI Path", uiPath);
                EditorGUILayout.Space();
                notUIPath = EditorGUILayout.TextField("NotUI Path", notUIPath);
                EditorGUILayout.Space();
                resourceFile = EditorGUILayout.TextField("Default text path", resourceFile);
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
