using UnityEngine;
using UnityEditor;

namespace QGUI
{
    public class QCreateSignInfo : PopupWindowContent
    {
        private QMarkupField mark;
        
        public override void OnOpen()
        {
            QCreateScript.isOne = false;
            mark = Selection.activeGameObject.GetComponent<QMarkupField>();
        }

        public override Vector2 GetWindowSize()
        {
            return new Vector2(100,50);
        }

        public override void OnGUI(Rect rect)
        {
            mark.jurisdiction = (QMarkupField.Jurisdiction)EditorGUILayout.EnumPopup(mark.jurisdiction);
            mark.index = EditorGUILayout.Popup(mark.index, mark.components);
            mark.component = mark.components[mark.index];
        }
    }
}
 