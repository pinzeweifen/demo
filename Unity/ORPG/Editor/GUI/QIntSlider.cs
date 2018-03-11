using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QIntSlider : QWidget, IQWidget
    {
        protected int m_Value;
        protected int m_Min;
        protected int m_Max;

        public int Value { get { return m_Value; } set { m_Value = value; } }
        public int Min { get { return m_Min; }set { m_Min = value; } }
        public int Max { get { return m_Max; }set { m_Max = value; } }

        public QIntSlider(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QIntSlider(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }
        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.IntSlider(rect, m_Name, m_Value, m_Min, m_Max);
        }

        public override IQObject Clone()
        {
            QIntSlider clone = base.Clone() as QIntSlider;
            clone.m_Value = m_Value;
            clone.m_Min = m_Min;
            clone.m_Max = m_Max;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QIntSlider ToIntSlider(this IQWidget widget)
        {
            if (widget is QIntSlider)
                return widget as QIntSlider;
            return null;
        }
    }
}
