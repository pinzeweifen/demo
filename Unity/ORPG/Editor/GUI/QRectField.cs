using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QRectField : QWidget, IQWidget
    {
        protected Rect m_Value;

        public Rect Value { get { return m_Value; } set { m_Value = value; } }

        public QRectField(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QRectField(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.RectField(rect, m_Name, m_Value);
        }

        public override IQObject Clone()
        {
            QRectField clone = base.Clone() as QRectField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QRectField ToQRectField(this IQWidget widget)
        {
            if (widget is QRectField)
                return widget as QRectField;
            return null;
        }
    }
}
