using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QFoldout : QWidget, IWidget
    {
        protected bool m_Value;

        public bool Value { get { return m_Value; } set { m_Value = value; } }

        public QFoldout(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QFoldout(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.Foldout(rect, m_Value, m_Name);
        }

        public override IObject Clone()
        {
            QFoldout clone = base.Clone() as QFoldout;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QFoldout ToFoldout(this IWidget widget)
        {
            if (widget is QFoldout)
                return widget as QFoldout;
            return null;
        }
    }
}
