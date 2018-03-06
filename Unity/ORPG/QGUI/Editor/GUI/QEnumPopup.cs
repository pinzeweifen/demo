using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QEnumPopup : QWidget, IWidget
    {
        protected Enum m_Value;

        public Enum Value { get { return m_Value; } set { m_Value = value; } }

        public QEnumPopup(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QEnumPopup(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.EnumPopup(rect,m_Name, m_Value);
        }

        public override IObject Clone()
        {
            QEnumPopup clone = base.Clone() as QEnumPopup;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QEnumPopup ToEnumPopup(this IWidget widget)
        {
            if (widget is QEnumPopup)
                return widget as QEnumPopup;
            return null;
        }
    }
}
