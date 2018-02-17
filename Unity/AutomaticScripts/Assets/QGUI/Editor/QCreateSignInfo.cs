using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace QGUI
{
    public class QCreateSignInfo : PopupWindowContent
    {
        private string typeMame;
        private string[] op;
        private QMarkupField mark;
        private MonoBehaviour[] coms;
        
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
            coms = mark.GetComponents<MonoBehaviour>();
            op = new string[coms.Length];

            for (int i = 0; i < coms.Length; i++)
            {
                typeMame = coms[i].GetType().Name;
                if (typeMame == "QMarkupField") continue;
                op[i] = typeMame;
            }

            mark.index = EditorGUILayout.Popup(mark.index, op);
            mark.component = op[mark.index];
        }
    }
}
 