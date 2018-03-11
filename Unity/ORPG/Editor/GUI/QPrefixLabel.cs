using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QPrefixLabel : QWidget, IQWidget
    {
        protected Rect m_ReturnRect;
        protected int m_ControlID;
        protected GUIContent m_Value;

        public int ControlID { get { return m_ControlID; }set { m_ControlID = value; } }
        public GUIContent Value { get { return m_Value; } set { m_Value = value; } }
        
        public QPrefixLabel(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QPrefixLabel(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
            m_Value = new GUIContent(name);
        }
        
        public Rect GetRect()
        {
            return m_ReturnRect;
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
             m_ReturnRect = EditorGUI.PrefixLabel(rect, m_ControlID,m_Value);
        }

        public override IQObject Clone()
        {
            QPrefixLabel clone = base.Clone() as QPrefixLabel;
            clone.m_Value = m_Value;
            clone.m_ReturnRect = m_ReturnRect;
            clone.m_ControlID = m_ControlID;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QPrefixLabel ToPrefixLabel(this IQWidget widget)
        {
            if (widget is QPrefixLabel)
                return widget as QPrefixLabel;
            return null;
        }
    }
}
