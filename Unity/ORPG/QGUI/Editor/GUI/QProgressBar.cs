using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QProgressBar : QWidget, IWidget
    {
        protected float m_Value;

        public float Value { get { return m_Value; } set { m_Value = value; } }

        public QProgressBar(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QProgressBar(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            EditorGUI.ProgressBar(rect, m_Value, m_Name);
        }

        public override IObject Clone()
        {
            QProgressBar clone = base.Clone() as QProgressBar;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QProgressBar ToProgressBar(this IWidget widget)
        {
            if (widget is QProgressBar)
                return widget as QProgressBar;
            return null;
        }
    }
}
