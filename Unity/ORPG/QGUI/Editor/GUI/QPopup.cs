using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QPopup : QWidget, IWidget
    {
        protected int m_Value;
        protected List<string> m_List = new List<string>();

        public int Value { get { return m_Value; }set { m_Value = value; } }


        public QPopup(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QPopup(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        public void Add(string value)
        {
            m_List.Add(value);
        }

        public void RemoveAt(int index)
        {
            if(index<m_List.Count)
            m_List.RemoveAt(index);
        }

        public void Remove(string value)
        {
            if(m_List.Contains(value))
            m_List.Remove(value);
        }

        public string GetValue(int index)
        {
            if(index<m_List.Count)
            return m_List[index];
            return string.Empty;
        }
        
        public string [] GetValues()
        {
            return m_List.ToArray();
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.Popup(rect, m_Name, m_Value,m_List.ToArray());
        }
        
        public override IObject Clone()
        {
            QPopup clone = base.Clone() as QPopup;
            clone.m_Value = m_Value;
            clone.m_List.AddRange(m_List);
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QPopup ToPopup(this IWidget widget)
        {
            if (widget is QPopup)
                return widget as QPopup;
            return null;
        }
    }
}
