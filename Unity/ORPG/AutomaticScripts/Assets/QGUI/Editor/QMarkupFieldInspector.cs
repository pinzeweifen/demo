using UnityEngine;
using UnityEditor;

namespace QRPG.AutoMaticScripts
{
    [CustomEditor(typeof(QMarkupField))]
    public class QMarkupFieldInspector : Editor
    {
        private string typeName;
        private string[] op;
        private Component[] coms;
        public override void OnInspectorGUI()
        {
            QMarkupField field = target as QMarkupField;

            field.jurisdiction = (QMarkupField.Jurisdiction)EditorGUILayout.EnumPopup("Jurisdiction", field.jurisdiction);

            coms = field.GetComponents<Component>();
            op = new string[coms.Length];

            field.components = new string[coms.Length];
            for(int i=0;i<coms.Length;i++)
            {
                if (coms[i] == null) continue;
                typeName = coms[i].GetType().Name;
                if (typeName == "QMarkupField") continue;
                op[i] = typeName;
                field.components[i] = typeName;
            }

            field.index = EditorGUILayout.Popup("ClassType", field.index, op);
            field.component = op[field.index];
        }
    }

}
