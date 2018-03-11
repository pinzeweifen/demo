using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QFloatField : QWidget, IQWidget
    {
        protected float m_Value;

        public float Value { get { return m_Value; } set { m_Value = value; } }

        public QFloatField(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QFloatField(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.FloatField(rect, m_Name, m_Value);
        }

        public override IQObject Clone()
        {
            QFloatField clone = base.Clone() as QFloatField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QFloatField ToFloatField(this IQWidget widget)
        {
            if (widget is QFloatField)
                return widget as QFloatField;
            return null;
        }
    }
}
