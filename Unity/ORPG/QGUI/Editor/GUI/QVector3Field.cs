using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QVector3Field : QWidget, IWidget
    {
        protected Vector3 m_Value;

        public Vector3 Value { get { return m_Value; } set { m_Value = value; } }

        public QVector3Field(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QVector3Field(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
           m_Value = EditorGUI.Vector3Field(rect, m_Name, m_Value); 
        }

        public override IObject Clone()
        {
            QVector3Field clone = base.Clone() as QVector3Field;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QVector3Field ToVector3Field(this IWidget widget)
        {
            if (widget is QVector3Field)
                return widget as QVector3Field;
            return null;
        }
    }
}
