using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QInspectorTitlebar : QWidget, IQWidget
    {
        protected bool m_Expandable;
        protected bool m_Value;
        protected List<Object> m_List = new List<Object>();
        
        public bool Value { get { return m_Value; } set { m_Value = value; } }
        public bool Expandable { get { return m_Expandable; }set { m_Expandable = value; } }
        public Object this[int index] {
            get { return m_List[index]; }
            set {
                if(index<=m_List.Count)
                    m_List[index] = value;
            }
        }

        public QInspectorTitlebar(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
        }

        public QInspectorTitlebar(EditorWindow window, string name, IQObject parent = null) : base(window, name, parent)
        {
        }

        public void Add(Object obj)
        {
            m_List.Add(obj);
        }

        public void RemoveAt(int index)
        {
            if (index >= m_List.Count || index < 0) return;
            m_List.RemoveAt(index);
        }

        public void Remove(Object obj)
        {
            if (m_List.Contains(obj))
                m_List.Remove(obj);
        }

        public void SetArray(Object[]objs)
        {
            m_List.Clear();
            m_List = new List<Object>();
            m_List.AddRange(objs);
        }

        public Object[] GetArray()
        {
            return m_List.ToArray();
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            EditorGUI.InspectorTitlebar(rect, m_Value, m_List.ToArray(),m_Expandable);
        }

        public override IQObject Clone()
        {
            QInspectorTitlebar clone = base.Clone() as QInspectorTitlebar;
            clone.m_Value = m_Value;
            clone.m_Expandable = m_Expandable;
            clone.m_List.AddRange(m_List);
            return clone;
        }
    }

    public static partial class QWidgetTo
    {
        public static QInspectorTitlebar ToInspectorTitlebar(this IQWidget widget)
        {
            if (widget is QInspectorTitlebar)
                return widget as QInspectorTitlebar;
            return null;
        }
    }
}
