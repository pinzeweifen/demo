using System;
using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QEnumPopup : QWidget, IQWidget
    {
        protected Enum m_Value;

        public Enum Value { get { return m_Value; } set { m_Value = value; } }

        public QEnumPopup(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QEnumPopup(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.EnumPopup(rect,m_Name, m_Value);
        }

        public override IQObject Clone()
        {
            QEnumPopup clone = base.Clone() as QEnumPopup;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QEnumPopup ToEnumPopup(this IQWidget widget)
        {
            if (widget is QEnumPopup)
                return widget as QEnumPopup;
            return null;
        }
    }
}
