using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QTagField : QWidget, IQWidget
    {
        protected string m_Value;

        public string Value { get { return m_Value; } set { m_Value = value; } }

        public QTagField(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QTagField(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.TagField(rect, m_Name, m_Value);
        }

        public override IQObject Clone()
        {
            QTagField clone = base.Clone() as QTagField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QTagField ToTagField(this IQWidget widget)
        {
            if (widget is QTagField)
                return widget as QTagField;
            return null;
        }
    }
}
