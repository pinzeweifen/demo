using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QSpriteField : QWidget, IQWidget
    {
        protected Sprite m_Value = new Sprite();

        public QSpriteField(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QSpriteField(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        public Sprite Value { get { return m_Value; }set { m_Value = value; } }
        
        public string GetValue()
        {
            if (m_Value != null)
                return AssetDatabase.GetAssetPath(m_Value);

            return string.Empty;
        }

        public void SetValue(string path)
        {
            m_Value = AssetDatabase.LoadAssetAtPath<Sprite>(path);
            if (m_Value == null)
            {
                m_Value = (Sprite)Resources.LoadAsync<Sprite>(path).asset;

                if(m_Value==null)
                    m_Value = new Sprite();
            }
                
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value= (Sprite) EditorGUI.ObjectField(rect, m_Name, m_Value, m_Value.GetType(), false);
        }

        public override IQObject Clone()
        {
            QSpriteField clone = base.Clone() as QSpriteField;
            clone.m_Value = m_Value;
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QSpriteField ToSpriteField(this IQWidget widget)
        {
            if (widget is QSpriteField)
                return widget as QSpriteField;
            return null;
        }
    }
}
