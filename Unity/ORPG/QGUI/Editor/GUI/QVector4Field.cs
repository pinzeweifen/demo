using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QVector4Field : QWidget, IWidget
    {
        protected Vector4 m_Value;

        public Vector4 Value { get { return m_Value; } set { m_Value = value; } }

        public QVector4Field(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QVector4Field(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.Vector4Field(rect, m_Name, m_Value);
        }

        public override IObject Clone()
        {
            QVector4Field clone = base.Clone() as QVector4Field;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QVector4Field ToVector4Field(this IWidget widget)
        {
            if (widget is QVector4Field)
                return widget as QVector4Field;
            return null;
        }
    }
}
