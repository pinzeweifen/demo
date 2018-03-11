using UnityEngine;
using UnityEditor;
using System.IO;
using QRPG.GUIEditor;

namespace QRPG.AutoMaticScripts
{
    [InitializeOnLoad]
    public class QCreateScript
    {
        public static bool isOne = false;
        public static bool isShow = true;
        public static GameObject selectGameObject;

        private static Event current;
        private static bool isSelectChanaged = false;
        private static QCreateSignInfo menu = new QCreateSignInfo();
        private static GUIContent add = new GUIContent("AddSign", "Add markup");
        private static GUIContent create = new GUIContent("Create", "Create a script");
        private static GUIContent remove = new GUIContent("RemoveSign", "Remove markup");
        
        [InitializeOnLoadMethod]
        public static void Init()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyOnGUI;
            Selection.selectionChanged += OnSelectionChanaged;
            SceneView.onSceneGUIDelegate += OnScene;
            if (!Directory.Exists(QCreateScriptsConfigure.notUIPath))
            {
                Directory.CreateDirectory( QCreateScriptsConfigure.notUIPath);
            }
            if (!Directory.Exists( QCreateScriptsConfigure.uiPath))
            {
                Directory.CreateDirectory( QCreateScriptsConfigure.uiPath);
            }
        }

        private static void OnHierarchyOnGUI(int instanceID, Rect selectionRect)
        {
            if (!isShow) return;
            ShowWindow();
        }

        private static void OnSelectionChanaged()
        {
            if (!isShow) return;

            if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<QMarkupField>())
            {
                isSelectChanaged = true;
                isOne = true;
            }
            else
            {
                isSelectChanaged = false;
            }
        }
        
        private static void OnScene(SceneView view)
        { 
            current = Event.current;

            ShowWindow();

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
            string resourceFile = QCreateScriptsConfigure.resourceFile;

            var endNameEditAction =
                ScriptableObject.CreateInstance<QDoCreateScript>();

            string pathName = string.Empty;
            if(selectGameObject.layer == 5)
            {
                pathName = string.Format("{0}/{1}UI.cs", QCreateScriptsConfigure.uiPath, selectGameObject.name);
            }
            else
            {
                pathName = string.Format("{0}/{1}UI.cs", QCreateScriptsConfigure.notUIPath, selectGameObject.name);
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

        private static void ShowWindow()
        {
            if (isSelectChanaged)
            {
                if (isOne && current.IsKeyDown(KeyCode.Escape))
                {
                    PopupWindow.Show(new Rect(new Vector2(current.mousePosition.x + 10, current.mousePosition.y + 10), Vector2.zero), menu);
                }
            }
        }
    }
}
