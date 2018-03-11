using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QPopup : QWidget, IQWidget
    {
        protected int m_Value;
        protected List<string> m_List = new List<string>();

        public int Value { get { return m_Value; }set { m_Value = value; } }


        public QPopup(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QPopup(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        public void Add(string value)
        {
            m_List.Add(value);
        }

        public void RemoveAt(int index)
        {
            if (index >= m_List.Count || index < 0) return;
            m_List.RemoveAt(index);
        }

        public void Remove(string value)
        {
            if (m_List.Contains(value))
                m_List.Remove(value);
        }

        public string GetValue(int index)
        {
            if (index >= m_List.Count || index < 0)
                return string.Empty;

            return m_List[index];
        }

        public string[] GetValues()
        {
            return m_List.ToArray();
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.Popup(rect, m_Name, m_Value,m_List.ToArray());
        }
        
        public override IQObject Clone()
        {
            QPopup clone = base.Clone() as QPopup;
            clone.m_Value = m_Value;
            clone.m_List.AddRange(m_List);
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QPopup ToPopup(this IQWidget widget)
        {
            if (widget is QPopup)
                return widget as QPopup;
            return null;
        }
    }
}
