using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QVector2Field : QWidget, IWidget
    {
        protected Vector2 m_Value;

        public Vector2 Value { get { return m_Value; } set { m_Value = value; } }

        public QVector2Field(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QVector2Field(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.Vector2Field(rect, m_Name,m_Value);
        }

        public override IObject Clone()
        {
            QVector2Field clone = base.Clone() as QVector2Field;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QVector2Field ToVector2Field(this IWidget widget)
        {
            if (widget is QVector2Field)
                return widget as QVector2Field;
            return null;
        }
    }
}
