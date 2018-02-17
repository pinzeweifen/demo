using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace QGUI
{
    [CustomEditor(typeof(QMarkupField))]
    public class QMarkupFieldInspector : Editor
    {
        private string typeMame;
        private string[] op;
        private MonoBehaviour[] coms;
        public override void OnInspectorGUI()
        {
            QMarkupField field = target as QMarkupField;

            field.jurisdiction = (QMarkupField.Jurisdiction)EditorGUILayout.EnumPopup("Jurisdiction", field.jurisdiction);

            coms = field.GetComponents<MonoBehaviour>();
            op = new string[coms.Length];

            for(int i=0;i<coms.Length;i++)
            {
                typeMame = coms[i].GetType().Name;
                if (typeMame == "QMarkupField") continue;
                op[i] = typeMame;
            }

            field.index = EditorGUILayout.Popup("ClassType", field.index, op);
            field.component = op[field.index];
        }
    }

}
