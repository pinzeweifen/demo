using System.Collections.Generic;

namespace QRPG.Frame
{
    public class QTirggerManager
    {
        protected Dictionary<int, QTirgger> m_Dic = new Dictionary<int, QTirgger>();

        public void Add(QTirgger tirgger)
        {
            m_Dic.Add(tirgger.ID, tirgger);
            tirgger.Register();
        }

        public void Remove(int id)
        {
            if (m_Dic.ContainsKey(id))
            {
                m_Dic[id].Logout();
                m_Dic.Remove(id);
            }
        }

        public void Open(int id)
        {
            m_Dic[id].Open();
        }

        public void Close(int id)
        {
            m_Dic[id].Close();
        }
    }
}
