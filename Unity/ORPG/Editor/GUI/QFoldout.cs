using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QFoldout : QWidget, IQWidget
    {
        protected bool m_Value;

        public bool Value { get { return m_Value; } set { m_Value = value; } }

        public QFoldout(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QFoldout(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.Foldout(rect, m_Value, m_Name);
        }

        public override IQObject Clone()
        {
            QFoldout clone = base.Clone() as QFoldout;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QFoldout ToFoldout(this IQWidget widget)
        {
            if (widget is QFoldout)
                return widget as QFoldout;
            return null;
        }
    }
}
