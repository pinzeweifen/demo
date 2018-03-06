
using UnityEngine;

namespace QGUI
{
    public class QViewItem
    {
        //protected Vector2 m_Size;
        protected float m_Height;
        protected string m_Name;

        public string Name
        {
            get { return m_Name; }
            set {
                m_Name = value;
                NameChangedEvent();
            }
        }

        public float Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }
        /*
        public Vector2 Size
        {
            get { return m_Size; }
            set { m_Size = value; }
        }
        */

        public IViewItem Clone()
        {
            QViewItem item = new QViewItem();
            item.m_Height = m_Height;
            item.m_Name = m_Name;
            return item as IViewItem;
        }

        public virtual void Update(Rect rect)
        {

        }

        protected virtual void NameChangedEvent()
        {

        }
    }
}
