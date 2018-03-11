using QRPG.BehaviourTree;

namespace QRPG.Frame
{
    public abstract class QTirgger
    {
        private static int m_TotalCount=0;

        protected int m_ID;
        protected string m_Name;
        protected bool m_Open = true;
        protected INode m_Root;
        protected string m_Annotation;
        
        public abstract void Register();
        public abstract void Logout();

        public int ID { get { return m_ID; } }
        public string Name { get { return m_Name; } }
        public string Annotation { get { return m_Annotation; } }

        public QTirgger(INode function, string name="", string annotation="")
        {
            m_ID = m_TotalCount;
            m_TotalCount++;

            m_Root = function;
            m_Name = name;
            m_Annotation = annotation;
        }

        public void Open()
        {
            m_Open = true;
        }

        public void Close()
        {
            m_Open = false;
        }

        public bool IsOpen()
        {
            return m_Open;
        }

        protected void Function(IEventInfo info)
        {
            m_Root.Tick(info);
        }
    }
}
