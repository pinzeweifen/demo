using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QTextField : QWidget, IWidget
    {
        protected string m_Value = string.Empty;

        public QTextField(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QTextField(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        public string Value { get { return m_Value; } set { m_Value = value; } }


        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.TextField(rect, m_Name, m_Value);
        }

        public override IObject Clone()
        {
            QTextField clone = base.Clone() as QTextField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QTextField ToTextField(this IWidget widget)
        {
            if (widget is QTextField)
                return widget as QTextField;
            return null;
        }
    }
}
