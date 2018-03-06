using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QTagField : QWidget, IWidget
    {
        protected string m_Value;

        public string Value { get { return m_Value; } set { m_Value = value; } }

        public QTagField(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QTagField(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.TagField(rect, m_Name, m_Value);
        }

        public override IObject Clone()
        {
            QTagField clone = base.Clone() as QTagField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QTagField ToTagField(this IWidget widget)
        {
            if (widget is QTagField)
                return widget as QTagField;
            return null;
        }
    }
}
