using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace QGUI
{
    public class QObject
    {
        private static int m_CreateCount=0;
        private static Dictionary<int,IObject> m_Objects = new Dictionary<int, IObject>();

        protected int m_ID;
        protected string m_Name;
        protected IObject m_Parent;
        protected List<IObject> m_Childs = new List<IObject>();
        protected EditorWindow m_Window;

        public int ID { get { return m_ID; } }
        public List<IObject> Childs { get { return m_Childs; } }
        public string Name { get { return m_Name; } set { m_Name = value; } }

        public IObject Parent
        {
            get { return m_Parent; }
            set
            {
                if (m_Parent != null)
                    m_Parent.Childs.Remove(this as IObject);
                
                m_Parent = value;

                if (value != null)
                    value.Childs.Add(this as IObject);
            }
        }

        public QObject(EditorWindow window,IObject parent=null)
        {
            m_Window = window;
            Parent = parent;

            m_ID = m_CreateCount;
            m_Objects[m_ID] = this as IObject;
            m_CreateCount++;
        }
        
        ~QObject()
        {
            m_Objects.Remove(m_ID);
        }

        public static IObject FindObject(int id)
        {
            if (m_Objects.ContainsKey(id))
                return m_Objects[id];

            return null;
        }

        public virtual IObject Clone()
        {
            QObject obj = new QObject(m_Window,m_Parent);
            obj.m_Name = m_Name;
            obj.m_Childs.AddRange(m_Childs);
            return obj as IObject;
        }

    }
}
