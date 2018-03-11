
using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QToggle : QWidget, IQWidget
    {
        protected bool m_Value;

        public bool Value { get { return m_Value; }set { m_Value = value; } }

        public QToggle(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QToggle(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
            
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.Toggle(rect, m_Value);
        }
        
        public override IQObject Clone()
        {
            QToggle clone = base.Clone() as QToggle;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QToggle ToToggle(this IQWidget widget)
        {
            if (widget is QToggle)
                return widget as QToggle;
            return null;
        }
    }
}
