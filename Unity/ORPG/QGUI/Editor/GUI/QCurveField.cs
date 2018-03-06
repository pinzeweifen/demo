using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QCurveField : QWidget, IWidget
    {
        protected Rect m_Ranges;
        protected Color m_Color;
        protected AnimationCurve m_Value;

        public AnimationCurve Value { get { return m_Value; } set { m_Value = value; } }
        public Color Color { get { return m_Color; }set { m_Color = value; } }
        public Rect Ranges { get { return m_Ranges; }set { m_Ranges = value; } }

        public QCurveField(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QCurveField(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.CurveField(rect, m_Name, m_Value, m_Color, m_Ranges);
        }

        public override IObject Clone()
        {
            QCurveField clone = base.Clone() as QCurveField;
            clone.m_Value = m_Value;
            clone.m_Color = m_Color;
            clone.m_Ranges = m_Ranges;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QCurveField ToCurveField(this IWidget widget)
        {
            if (widget is QCurveField)
                return widget as QCurveField;
            return null;
        }
    }
}
