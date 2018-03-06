using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QMinMaxSlider : QWidget, IWidget
    {
        protected float m_MinValue;
        protected float m_MaxValue;
        protected float m_MinLimit;
        protected float m_MaxLimit;

        public float MinValue { get { return m_MinValue; } set { m_MinValue = value; } }
        public float MaxValue { get { return m_MaxValue; } set { m_MaxValue = value; } }
        public float MinLimit { get { return m_MinLimit; } set { m_MinLimit = value; } }
        public float MaxLimit { get { return m_MaxLimit; } set { m_MaxLimit = value; } }

        public QMinMaxSlider(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QMinMaxSlider(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            EditorGUI.MinMaxSlider(rect, m_Name, ref m_MinValue, ref m_MaxValue, m_MinLimit, m_MaxLimit);
        }

        public override IObject Clone()
        {
            QMinMaxSlider clone = base.Clone() as QMinMaxSlider;
            clone.m_MinLimit = m_MinLimit;
            clone.m_MinValue = m_MinValue;
            clone.m_MaxLimit = m_MaxLimit;
            clone.m_MaxValue = m_MaxValue;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QMinMaxSlider ToMinMaxSlider(this IWidget widget)
        {
            if (widget is QMinMaxSlider)
                return widget as QMinMaxSlider;
            return null;
        }
    }
}
