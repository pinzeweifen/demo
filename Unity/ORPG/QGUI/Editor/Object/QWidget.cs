using System;
using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public partial class QWidget:QObject, IObject
    {
        protected static readonly Rect m_DefaultRect = new Rect(0, 0, 100, 100);
        protected Rect m_Rect = m_DefaultRect;
        protected bool m_IsShow = true;

        public Vector2 Size { get { return new Vector2(m_Rect.width, m_Rect.height); } }
        /// <summary>
        /// 全局坐标
        /// </summary>
        public Vector2 GlobalPos { get { return new Vector2(m_Rect.x,m_Rect.y); } }
        public float GlobalX { get { return m_Rect.x; } }
        public float GlobalY { get { return m_Rect.y; } }
        public float Width { get { return m_Rect.width; } }
        public float Height { get { return m_Rect.height; } }

        /// <summary>
        /// 相对坐标
        /// </summary>
        public Vector2 Pos {
            get {
                if (m_Parent != null)
                {
                    var widget = m_Parent as QWidget;
                    return new Vector2(m_Rect.x - widget.m_Rect.x, m_Rect.y - widget.m_Rect.y);
                }
                return new Vector2(m_Rect.x,m_Rect.y);
            }
        }
        public float X {
            get {
                if (m_Parent != null)
                {
                    var widget = m_Parent as QWidget;
                    return m_Rect.x - widget.m_Rect.x;
                }
                return m_Rect.x;
            }
        }
        public float Y {
            get{
                if (m_Parent != null)
                {
                    var widget = m_Parent as QWidget;
                    return m_Rect.y - widget.m_Rect.y;
                }
                return m_Rect.y;
            }
        }

        protected virtual void scrollWhellEvent(float delta) { }
        protected virtual void mousePressEvent(MouseButton button, Vector2 pos) { }
        protected virtual void mouseMoveEvent(Vector2 pos) { }
        protected virtual void mouseReleaseEvent(Vector2 pos) { }
        protected virtual void ResizeEvent(float width, float height) { }
        protected virtual void MoveEvent(float x, float y) { }
        protected virtual void ShowEvent() { }
        protected virtual void HideEvent() { }
        protected virtual void CloseEvent() { }
        protected virtual void PaintEvent(Event current,Rect rect) { }
        protected virtual void ContextMenuEvent(GenericMenu menu, object value) { }
    }

    public partial class QWidget
    {
        public QWidget(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }

        public QWidget(EditorWindow window, string name, IObject parent = null) : base(window, parent)
        {
            m_Name = name;
        }

        public override IObject Clone()
        {
            QWidget widget = base.Clone() as QWidget;
            widget.m_Rect = m_Rect;
            widget.m_IsShow = m_IsShow;

            return widget;
        }

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Move(float x, float y)
        {

            if (m_Parent != null)
            {
                var widget = m_Parent as QWidget;

                m_Rect.x = widget.X + x;
                m_Rect.y = widget.Y + y;
            }
            else
            {
                m_Rect.x = x;
                m_Rect.y = y;
            }

            MoveEvent(m_Rect.x, m_Rect.y);
        }

        public void Move(Vector2 pos)
        {
            Move(pos.x, pos.y);
        }

        /// <summary>
        /// 设置大小
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Resize(float width, float height)
        {
            m_Rect.width = width;
            m_Rect.height = height;

            ResizeEvent(width, height);
        }

        public void Resize(Vector2 size)
        {
            Resize(size.x, size.y);
        }

        /// <summary>
        /// 设置位置和大小
        /// </summary>
        /// <param name="rect"></param>
        public void SetGeometry(Rect rect)
        {
            Move(rect.x, rect.y);
            Resize(rect.width, rect.height);
        }

        public Rect GetGeometry()
        {
            return m_Rect;
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        public void Hide()
        {
            m_IsShow = false;
            HideEvent();
        }

        /// <summary>
        /// 显示
        /// </summary>
        public void Show()
        {
            m_IsShow = true;
            ShowEvent();
        }

        /// <summary>
        /// 关闭【只是移除父对象和子对象的关系】
        /// </summary>
        public void Close()
        {
            CloseEvent();
            m_Parent.Childs.Remove(this);
            m_Parent = null;
        }
        
        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="current"></param>
        /// <param name="value"></param>
        public void OnGUI(Event current,object value=null)
        {
            if (!m_IsShow) return;

            if (current.IsMouseDown(m_Rect))
            {
                mousePressEvent((MouseButton)current.button, current.mousePosition);
            }

            if (current.IsDrag())
            {
                mouseMoveEvent(current.mousePosition);
            }

            if (current.IsMouseUp())
            {
                mouseReleaseEvent(current.mousePosition);
            }

            if (current.IsScrollWhell(m_Rect))
            {
                scrollWhellEvent(current.GetScrollDelta());
            }
            
            PaintEvent(current, value == null ? m_Rect : (Rect)value);
            
            for (int i = 0; i < m_Childs.Count; i++)
            {
                (m_Childs[i] as QWidget).OnGUI(current, value);
            }
        }

        protected void ContextMenu(object value =null)
        {
            GenericMenu menu = new GenericMenu();
            ContextMenuEvent(menu, value);
            menu.ShowAsContext();
        }
    }
}
