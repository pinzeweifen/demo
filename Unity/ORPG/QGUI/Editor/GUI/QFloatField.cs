using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QFloatField : QWidget, IWidget
    {
        protected float m_Value;

        public float Value { get { return m_Value; } set { m_Value = value; } }

        public QFloatField(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QFloatField(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.FloatField(rect, m_Name, m_Value);
        }

        public override IObject Clone()
        {
            QFloatField clone = base.Clone() as QFloatField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QFloatField ToFloatField(this IWidget widget)
        {
            if (widget is QFloatField)
                return widget as QFloatField;
            return null;
        }
    }
}
