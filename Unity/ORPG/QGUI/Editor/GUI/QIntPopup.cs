using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QIntPopup : QWidget, IWidget
    {
        protected int m_Value;
        protected List<string> m_Display = new List<string>();
        protected List<int> m_Values = new List<int>();

        public int Value { get { return m_Value; } set { m_Value = value; } }
        
        public QIntPopup(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QIntPopup(EditorWindow window, string name, IObject parent = null) : base(window, name, parent)
        {
        }

        public void Add(string name, int value)
        {
            m_Display.Add(name);
            m_Values.Add(value);
        }

        public void RemoveAt(int index)
        {
            m_Display.RemoveAt(index);
            m_Values.RemoveAt(index);
        }

        public string GetName(int index)
        {
            if (index >= m_Display.Count||index<0) return string.Empty;
            return m_Display[index];
        }

        public int GetValue(int index)
        {
            return m_Values[index];
        }

        public void SetValue(int index, string name, int value)
        {
            if (index >= m_Display.Count||index<0) return;
            m_Display[index] = name;
            m_Values[index] = value;
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            m_Value = EditorGUI.IntPopup(rect, m_Name, m_Value, m_Display.ToArray(), m_Values.ToArray());
        }
        
        public override IObject Clone()
        {
            QIntPopup clone = base.Clone() as QIntPopup;
            clone.m_Value = m_Value;
            clone.m_Display.AddRange(m_Display);
            clone.m_Values.AddRange(m_Values);
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QIntPopup ToIntPopup(this IWidget widget)
        {
            if (widget is QIntPopup)
                return widget as QIntPopup;
            return null;
        }
    }
}
