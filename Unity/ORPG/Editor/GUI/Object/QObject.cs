using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace QRPG.GUIEditor
{
    public class QObject
    {
        private static int m_CreateCount=0;
        private static Dictionary<int,IQObject> m_Objects = new Dictionary<int, IQObject>();

        protected int m_ID;
        protected string m_Name;
        protected IQObject m_Parent;
        protected List<IQObject> m_Childs = new List<IQObject>();
        protected EditorWindow m_Window;

        public int ID { get { return m_ID; } }
        public List<IQObject> Childs { get { return m_Childs; } }
        public string Name { get { return m_Name; } set { m_Name = value; } }

        public IQObject Parent
        {
            get { return m_Parent; }
            set
            {
                if (m_Parent != null)
                    m_Parent.Childs.Remove(this as IQObject);
                
                m_Parent = value;

                if (value != null)
                    value.Childs.Add(this as IQObject);
            }
        }

        public QObject(EditorWindow window,IQObject parent=null)
        {
            m_Window = window;
            Parent = parent;

            m_ID = m_CreateCount;
            m_Objects[m_ID] = this as IQObject;
            m_CreateCount++;
        }
        
        ~QObject()
        {
            m_Objects.Remove(m_ID);
        }

        public static IQObject FindObject(int id)
        {
            if (m_Objects.ContainsKey(id))
                return m_Objects[id];

            return null;
        }

        public virtual IQObject Clone()
        {
            QObject obj = new QObject(m_Window,m_Parent);
            obj.m_Name = m_Name;
            obj.m_Childs.AddRange(m_Childs);
            return obj as IQObject;
        }

    }
}
