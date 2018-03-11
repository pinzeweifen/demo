using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QPasswordField : QWidget, IQWidget
    {
        protected string m_Value;

        public string Value { get { return m_Value; } set { m_Value = value; } }

        public QPasswordField(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QPasswordField(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.PasswordField(rect, m_Name, m_Value);
        }

        public override IQObject Clone()
        {
            QPasswordField clone = base.Clone() as QPasswordField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QPasswordField ToPasswordField(this IQWidget widget)
        {
            if (widget is QPasswordField)
                return widget as QPasswordField;
            return null;
        }
    }
}
