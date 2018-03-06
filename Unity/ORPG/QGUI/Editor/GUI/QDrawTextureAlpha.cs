using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QDrawTextureAlpha : QWidget, IWidget
    {
        protected Texture m_Value;

        public Texture Value { get { return m_Value; } set { m_Value = value; } }

        public QDrawTextureAlpha(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QDrawTextureAlpha(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
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
            EditorGUI.DrawTextureAlpha(rect, m_Value);
        }

        public override IObject Clone()
        {
            QDrawTextureAlpha clone = base.Clone() as QDrawTextureAlpha;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QDrawTextureAlpha ToDrawTextureAlpha(this IWidget widget)
        {
            if (widget is QDrawTextureAlpha)
                return widget as QDrawTextureAlpha;
            return null;
        }
    }
}
