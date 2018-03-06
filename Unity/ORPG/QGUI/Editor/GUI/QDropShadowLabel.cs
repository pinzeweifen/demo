using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QDropShadowLabel : QWidget, IWidget
    {
        protected string m_Value;

        public string Value { get { return m_Value; }set { m_Value = value; } }
        public QDropShadowLabel(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QDropShadowLabel(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            EditorGUI.DropShadowLabel(rect,m_Name, m_Value);
        }

        public override IObject Clone()
        {
            QDropShadowLabel clone = base.Clone() as QDropShadowLabel;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QDropShadowLabel ToDropShadowLabel(this IWidget widget)
        {
            if (widget is QDropShadowLabel)
                return widget as QDropShadowLabel;
            return null;
        }
    }
}
