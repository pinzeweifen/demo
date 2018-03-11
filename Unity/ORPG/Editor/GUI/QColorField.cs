using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QColorField : QWidget, IQWidget
    {
        protected Color m_Value;

        public Color Value { get { return m_Value; } set { m_Value = value; } }

        public QColorField(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QColorField(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.ColorField(rect,m_Name, m_Value);
        }

        public override IQObject Clone()
        {
            QColorField clone = base.Clone() as QColorField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QColorField ToColorField(this IQWidget widget)
        {
            if (widget is QColorField)
                return widget as QColorField;
            return null;
        }
    }
}
