﻿
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QTextArea : QWidget, IWidget
    {
        protected string m_Value;

        public string Value { get { return m_Value; } set { m_Value = value; } }

        public QTextArea(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QTextArea(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {

        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.TextArea(rect, m_Value);
        }

        public override IObject Clone()
        {
            QTextArea clone = base.Clone() as QTextArea;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QTextArea ToTextArea(this IWidget widget)
        {
            if (widget is QTextArea)
                return widget as QTextArea;
            return null;
        }
    }
}
