using UnityEngine;
using UnityEditor;
using System.IO;

namespace QGUI
{
    [InitializeOnLoad]
    public class QCreateScript
    {
        private static Event current;
        public static GameObject selectGameObject;
        private static GUIContent add = new GUIContent("AddSign", "添加标记");
        private static GUIContent create = new GUIContent("Create", "创建脚本");
        private static GUIContent remove = new GUIContent("RemoveSign", "移除标记");
        
        [InitializeOnLoadMethod]
        public static void Init()
        {
            SceneView.onSceneGUIDelegate += OnScene;
            if (!Directory.Exists("Assets/"+ QCreateScripteConfigure.notUIPath))
            {
                Directory.CreateDirectory("Assets/" + QCreateScripteConfigure.notUIPath);
            }
            if (!Directory.Exists("Assets/" + QCreateScripteConfigure.uiPath))
            {
                Directory.CreateDirectory("Assets/" + QCreateScripteConfigure.uiPath);
            }
        }
        
        private static void OnScene(SceneView view)
        {
            current = Event.current;
            if (Selection.activeGameObject != null)
            {
                if (current.IsButton(MouseButton.Right) && current.IsMouseDown())
                {
                    selectGameObject = Selection.activeGameObject;

                    GenericMenu menu = new GenericMenu();
                    menu.AddItem(create, false, OnCreate);
                    menu.AddSeparator("");
                    menu.AddItem(add, false, OnAdd);
                    if (selectGameObject.GetComponent<QMarkupField>())
                        menu.AddItem(remove, false, OnRemove);
                    menu.ShowAsContext();
                }
            }
        }

        private static void OnCreate()
        {
            string resourceFile = "Assets/" + QCreateScripteConfigure.resourceFile;

            var endNameEditAction =
                ScriptableObject.CreateInstance<QDoCreateScript>();

            string pathName = string.Empty;
            if(selectGameObject.layer == 5)
            {
                pathName = string.Format("{0}/{1}UI.cs", QCreateScripteConfigure.uiPath, selectGameObject.name);
            }
            else
            {
                pathName = string.Format("{0}/{1}UI.cs", QCreateScripteConfigure.notUIPath, selectGameObject.name);
            }

            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, endNameEditAction,
                pathName, null, resourceFile);
        }
        
        private static void OnAdd()
        {
            foreach(var obj in Selection.gameObjects)
            {
                obj.AddComponent<QMarkupField>();
            }
        }

        private static void OnRemove()
        {
            foreach (var obj in Selection.gameObjects)
            {
                Object.DestroyImmediate( obj.GetComponent<QMarkupField>());
            }
        }
    }
}
