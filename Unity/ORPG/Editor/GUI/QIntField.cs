using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QIntField : QWidget, IQWidget
    {
        protected int m_Value;

        public QIntField(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QIntField(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        public int Value { get { return m_Value; }set { m_Value = value; } }
        
        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.IntField(rect, m_Name, m_Value);
        }

        public override IQObject Clone()
        {
            QIntField clone = base.Clone() as QIntField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QIntField ToIntField(this IQWidget widget)
        {
            if (widget is QIntField)
                return widget as QIntField;
            return null;
        }
    }
}
