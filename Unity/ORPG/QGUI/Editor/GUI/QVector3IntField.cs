using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QVector3IntField : QWidget, IWidget
    {
        protected Vector3Int m_Value;

        public Vector3Int Value { get { return m_Value; } set { m_Value = value; } }

        public QVector3IntField(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QVector3IntField(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.Vector3IntField(rect, m_Name, m_Value);
        }

        public override IObject Clone()
        {
            QVector3IntField clone = base.Clone() as QVector3IntField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QVector3IntField ToVector3IntField(this IWidget widget)
        {
            if (widget is QVector3IntField)
                return widget as QVector3IntField;
            return null;
        }
    }
}
