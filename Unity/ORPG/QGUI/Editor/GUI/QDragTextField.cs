using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QDragTextField : QWidget, IWidget
    {
        protected string m_Value;

        public string Value { get { return m_Value; }set { m_Value = value; } }

        public QDragTextField(EditorWindow window, IObject parent = null) : base(window, parent)
        {
            
        }

        public QDragTextField(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.TextField(rect, m_Name, m_Value);
            if (Event.current.IsDragPerform(rect))
            {
                m_Value = DragAndDrop.paths[0];
                current.Use();
            }
        }

        public override IObject Clone()
        {
            QDragTextField clone = base.Clone() as QDragTextField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QDragTextField ToDragTextField(this IWidget widget)
        {
            if (widget is QDragTextField)
                return widget as QDragTextField;
            return null;
        }
    }
}
