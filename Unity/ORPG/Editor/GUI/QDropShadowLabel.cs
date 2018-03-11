using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QDropShadowLabel : QWidget, IQWidget
    {
        protected string m_Value;

        public string Value { get { return m_Value; }set { m_Value = value; } }
        public QDropShadowLabel(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QDropShadowLabel(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            EditorGUI.DropShadowLabel(rect,m_Name, m_Value);
        }

        public override IQObject Clone()
        {
            QDropShadowLabel clone = base.Clone() as QDropShadowLabel;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QDropShadowLabel ToDropShadowLabel(this IQWidget widget)
        {
            if (widget is QDropShadowLabel)
                return widget as QDropShadowLabel;
            return null;
        }
    }
}
