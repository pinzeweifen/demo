using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QVector2IntField : QWidget, IWidget
    {
        protected Vector2Int m_Value;

        public Vector2Int Value { get { return m_Value; } set { m_Value = value; } }

        public QVector2IntField(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QVector2IntField(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.Vector2IntField(rect, m_Name, m_Value);
        }

        public override IObject Clone()
        {
            QVector2IntField clone = base.Clone() as QVector2IntField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QVector2IntField ToVector2Int(this IWidget widget)
        {
            if (widget is QVector2IntField)
                return widget as QVector2IntField;
            return null;
        }
    }
}
