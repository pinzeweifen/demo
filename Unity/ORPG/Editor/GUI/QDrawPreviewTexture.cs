using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QDrawPreviewTexture : QWidget, IQWidget
    {
        protected Texture m_Value;

        public Texture Value { get { return m_Value; } set { m_Value = value; } }

        public QDrawPreviewTexture(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QDrawPreviewTexture(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        public string GetValue()
        {
            if (m_Value != null)
                return AssetDatabase.GetAssetPath(m_Value);

            return string.Empty;
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            EditorGUI.DrawPreviewTexture(rect, m_Value);
        }

        public override IQObject Clone()
        {
            QDrawPreviewTexture clone = base.Clone() as QDrawPreviewTexture;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QDrawPreviewTexture ToDrawPreviewTexture(this IQWidget widget)
        {
            if (widget is QDrawPreviewTexture)
                return widget as QDrawPreviewTexture;
            return null;
        }
    }
}
