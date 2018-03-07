using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using QGUI;

namespace QGUI
{
    public abstract class QAbstractItemView : QWidget, IWidget
    {
        protected static readonly Rect m_DefaultShowRect = new Rect(0, 0, 0, 10);

        protected Vector2 m_ScrollToPos;
        protected bool m_IsScrollTo = false;
        protected float m_Space = 2;
        protected int m_Index = -1;
        protected Vector2 m_ScrollPos;
        protected Rect m_ShowRect = m_DefaultShowRect;
        protected List<IViewItem> m_List = new List<IViewItem>();

        public int Index { get { return m_Index; } }
        public int Count { get { return m_List.Count; } }
        public float Space { get { return m_Space; } set { m_Space = value; } }

        public IViewItem this[int index] {
            get {
                if(index<m_List.Count)
                return m_List[index];
                return null;
            }
        }

        public Action<QAbstractItemView, int> onCurrentChanged;
        public Action<GenericMenu, bool> onContextMenu;

        //protected abstract Rect DrawItem(float totalHeight, int index);
        protected abstract void DrawItem(Rect rect, int index);



        public QAbstractItemView(EditorWindow window, IObject parent = null) : base(window, parent)
        {

        }

        public new IObject Clone()
        {
            QAbstractItemView view = base.Clone() as QAbstractItemView;
            view.m_List.AddRange(m_List);
            view.m_Space = m_Space;
            view.m_ShowRect = m_ShowRect;
            return view;
        }

        public void Add(IViewItem item)
        {
            m_List.Add(item);
            //m_ShowRect.width = item.Size.x > m_ShowRect.width ? item.Size.x : m_ShowRect.width;
            //m_ShowRect.height += item.Size.y;
            m_ShowRect.height += (item.Height + 5);
        }

        public void Remove(IViewItem item)
        {
            if (m_List.Contains(item))
            {
                m_List.Remove(item);
                //m_ShowRect.height -= item.Size.y;
                m_ShowRect.height -= (item.Height + m_Space);
                // InitWidth();
            }
        }

        public IViewItem RemoveAt(int index)
        {
            if (m_List.Count > index)
            {
                var tmp = m_List[index];
                m_List.RemoveAt(index);
                m_ShowRect.height -= (tmp.Height + m_Space);
                //InitWidth();
                return tmp;
            }
            return null;
        }
        
        /// <summary>
        /// 设置当前索引
        /// </summary>
        /// <param name="index"></param>
        public void SetIndex(int index)
        {
            if (index >= m_List.Count || index<0) return;
            m_IsScrollTo = true;
            m_Index = index;
        }
        
        protected override void PaintEvent(Event current,Rect rect)
        {
            IViewItem item;
            var totalHeight = 0f;
            Rect scrollTo = Rect.zero;
            m_ScrollToPos = m_ScrollPos;

            m_ScrollPos = GUI.BeginScrollView(m_Rect, m_ScrollPos, m_ShowRect);
            {
                for (int i = 0; i < m_List.Count; i++)
                {
                    item = m_List[i];

                    rect = new Rect(
                        2, 
                        0 != i ? totalHeight += (item.Height + m_Space) : 0, 
                        m_Rect.width - 18, 
                        item.Height);

                    var controlName = string.Format("Object_{0}_{1}", m_ID, i);
                    GUI.SetNextControlName(controlName);
                    DrawItem(rect, i);
                    
                    if(m_Index == i)
                        scrollTo = rect;

                    if (current.IsMouseDown(rect))
                    {
                        m_Index = i;
                        if (onCurrentChanged != null)
                            onCurrentChanged(this, m_Index);
                        m_Window.Repaint();
                        GUI.FocusControl(controlName);
                    }
                    if (current.IsContextClick(rect))
                    {
                        ContextMenu(true);
                        current.Use();
                    }
                }

                if (m_IsScrollTo)
                {
                    if(m_ScrollToPos == m_ScrollPos)
                        GUI.ScrollTo(scrollTo);
                    else
                        m_IsScrollTo = false;
                }
            }
            GUI.EndScrollView();
            
            if (current.IsContextClick(m_Rect))
            {
                ContextMenu(false);
                current.Use();
            }
        }


        protected override void ContextMenuEvent(GenericMenu menu, object value)
        {
            if (onContextMenu != null)
                onContextMenu(menu, Convert.ToBoolean(value));

        }

        private void InitWidth()
        {/*
            m_ShowRect.width = 0;
            for(int i = 0; i < m_List.Count; i++)
            {
                if (m_List[i].Size.x > m_ShowRect.width)
                {
                    m_ShowRect.width = m_List[i].Size.x;
                }
            }*/
        }
    }
}