using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QButton : QWidget, IWidget
    {
        protected Action m_Value;

        public Action Click { set { m_Value = value; } }

        public QButton(EditorWindow window, Action click, string name = "", IObject parent = null) : base(window,name, parent)
        {
            m_Value = click;
        }
        
        protected override void PaintEvent(Event current, Rect rect)
        {
            if (GUI.Button(rect, m_Name))
            {
                m_Value();
            }
        }

        public override IObject Clone()
        {
            QButton clone = base.Clone() as QButton;
            clone.m_Value = m_Value;
            return clone;
        }
    }
    
    public static partial class QWidgetTo
    {
        public static QButton ToButton(this IWidget widget)
        {
            if (widget is QButton)
                return widget as QButton;
            return null;
        }
    }
}
