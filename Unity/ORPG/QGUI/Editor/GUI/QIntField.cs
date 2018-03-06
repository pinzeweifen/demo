using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QIntField : QWidget, IWidget
    {
        protected int m_Value;

        public QIntField(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QIntField(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        public int Value { get { return m_Value; }set { m_Value = value; } }
        
        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.IntField(rect, m_Name, m_Value);
        }

        public override IObject Clone()
        {
            QIntField clone = base.Clone() as QIntField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QIntField ToIntField(this IWidget widget)
        {
            if (widget is QIntField)
                return widget as QIntField;
            return null;
        }
    }
}
