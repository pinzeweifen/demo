using UnityEngine;
using UnityEditor;

namespace QRPG.GUIEditor
{
    public class QLabelField : QWidget,IQWidget
    {
        protected string m_Value;

        public QLabelField(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QLabelField(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        public string Value { get { return m_Value; } set { m_Value = value; } }
        
        
        protected override void PaintEvent(Event current, Rect rect)
        {
            EditorGUI.LabelField(rect, m_Name, m_Value);
        }

        public override IQObject Clone()
        {
            QLabelField clone = base.Clone() as QLabelField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QLabelField ToLabelField(this IQWidget widget)
        {
            if(widget is QLabelField)
                return widget as QLabelField;
            return null;
        }
    }
}