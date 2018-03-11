using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QMoveWidget : QWidget, IQWidget
    {
        protected bool isDrag = false;
        protected Vector2 m_Pos;
        protected IQWidget m_Target;
        protected bool m_isMoveX = true;
        protected bool m_isMoveY = true;
        protected float m_MinX = -1;
        protected float m_MinY = -1;
        protected float m_MaxX = -1;
        protected float m_MaxY = -1;


        public bool IsMoveX { get { return m_isMoveX; }set { m_isMoveX = value; } }
        public bool IsMoveY { get { return m_isMoveY; } set { m_isMoveY = value; } }
        public float MinX { set { m_MinX = value; } }
        public float MinY { set { m_MinY = value; } }
        public float MaxX { set { m_MaxX = value; } }
        public float MaxY { set { m_MaxY = value; } }

        public new IQObject Clone()
        {
            QMoveWidget clone = base.Clone() as QMoveWidget;
            clone.m_Target = m_Target;
            clone.m_isMoveX = m_isMoveX;
            clone.m_isMoveY = m_isMoveY;
            clone.m_MinX = m_MinX;
            clone.m_MaxX = m_MaxX;
            clone.m_MinY = m_MinY;
            clone.m_MaxY = m_MaxY;
            return clone;
        }

        public QMoveWidget(EditorWindow window, IQWidget target, IQObject parent = null) : base(window, parent)
        {
            m_Target = target;
        }

        protected override void PaintEvent(Event current, Rect rect)
        {
            SetGeometry(m_Target.GetGeometry());
        }

        protected override void mousePressEvent(MouseButton button, Vector2 pos)
        {
            if(button == MouseButton.Left)
            {
                m_Pos = pos - m_Target.Pos;
                isDrag = true;
            }
        }

        protected override void mouseMoveEvent(Vector2 pos)
        {
            if (isDrag)
            {
                var move = pos - m_Pos;
                if (!m_isMoveX)
                    move.x = m_Target.X;

                if (!m_isMoveY)
                    move.y = m_Target.Y;

                if (m_MinX != -1 && move.x < m_MinX)
                    move.x = m_MinX;

                if (m_MinY != -1 && move.y < m_MinY)
                    move.y = m_MinY;

                if (m_MaxY != -1 && move.y > m_MaxY)
                    move.y = m_MaxY;

                if (m_MaxX != -1 && move.x > m_MaxX)
                    move.x = m_MaxX;

                m_Target.Move(move);
                m_Pos = pos - m_Target.Pos;
                m_Window.Repaint();
            }
        }
        
        protected override void mouseReleaseEvent(Vector2 pos)
        {
            if (isDrag)
            {
                isDrag = false;
            }
        }
    }
}
