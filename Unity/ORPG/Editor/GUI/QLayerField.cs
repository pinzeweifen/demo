using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QLayerField : QWidget, IQWidget
    {
        protected int m_Value;

        public int Value { get { return m_Value; } set { m_Value = value; } }

        public QLayerField(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QLayerField(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }
        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.LayerField(rect, m_Name, m_Value);
        }

        public override IQObject Clone()
        {
            QLayerField clone = base.Clone() as QLayerField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QLayerField ToLayerField(this IQWidget widget)
        {
            if (widget is QLayerField)
                return widget as QLayerField;
            return null;
        }
    }
}
