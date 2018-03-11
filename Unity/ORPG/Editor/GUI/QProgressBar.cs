using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QProgressBar : QWidget, IQWidget
    {
        protected float m_Value;

        public float Value { get { return m_Value; } set { m_Value = value; } }

        public QProgressBar(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QProgressBar(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            EditorGUI.ProgressBar(rect, m_Value, m_Name);
        }

        public override IQObject Clone()
        {
            QProgressBar clone = base.Clone() as QProgressBar;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QProgressBar ToProgressBar(this IQWidget widget)
        {
            if (widget is QProgressBar)
                return widget as QProgressBar;
            return null;
        }
    }
}
