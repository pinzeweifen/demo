using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QDrawRect : QWidget, IWidget
    {
        protected Color m_Value;

        public Color Value { get { return m_Value; }set { m_Value = value; } }

        public QDrawRect(EditorWindow window, Color color, IObject parent = null) : base(window, parent)
        {
            m_Value = color;
        }

        public QDrawRect(EditorWindow window, Color color, string name, IObject parent = null) : base(window, name, parent)
        {
            m_Value = color;
        }

        public QDrawRect(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        public QDrawRect(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {

            EditorGUI.DrawRect(rect, m_Value);
        }

        public override IObject Clone()
        {
            QDrawRect clone = base.Clone() as QDrawRect;
            clone.m_Value = m_Value;
            return clone;
        }
    }
    
    public static partial class QWidgetTo
    {
        public static QDrawRect ToDrawRect(this IWidget widget)
        {
            if (widget is QDrawRect)
                return widget as QDrawRect;
            return null;
        }
    }
}
