using System.Collections.Generic;
using QRPG.BehaviourTree;

namespace QRPG.Frame
{
    public partial class QAritcleArray
    {
        protected int m_SaveMax;
        protected QArticle[] m_List;
        protected EventInfo onUpdate;

        public QArticle this[int index]
        {
            get { return m_List[index]; }
        }
        
        public QAritcleArray(int count, int max)
        {
            m_List = new QArticle[count];
            m_SaveMax = max;
        }
        
        public bool Add(QArticle article)
        {
            var indexs = GetEmptys();
            var list = GetSplit(article);
            if (list.Length > indexs.Length) return true;
            for(int i = 0; i < list.Length; i++)
            {
                m_List[indexs[i]] = list[i];
                if (onUpdate != null) onUpdate(new IndexInfo (indexs[i]));
            }
            
            return false;
        }

        public bool Insert(int index, QArticle article)
        {
            if (m_List[index] != null || article.Count > m_SaveMax) return true;

            m_List[index] = article;
            if (onUpdate != null) onUpdate(new IndexInfo(index));

            return false;
        }

        public QArticle RemoveAt(int index, int count)
        {
            if (index < 0 ||
                index >= m_List.Length ||
                m_List[index] == null||
                m_List[index].Count<count) return null;

            var value = m_List[index].Clone();
            value.Count = count;

            if(m_List[index].Count != count)
                m_List[index].Count -= count;
            else
                m_List[index] = null;

            if (onUpdate != null) onUpdate(new IndexInfo(index));

            return value;
        }

        public int[] GetEmptys()
        {
            List<int> emptys = new List<int>();
            for (int i = 0; i < m_List.Length; i++)
            {
                if (m_List[i] == null)
                {
                    emptys.Add(i);
                }
            }
            
            return emptys.ToArray();
        }
        
        public QArticle[] GetSplit(QArticle article)
        {
            int count = article.Count / m_SaveMax;
            var list = new QArticle[count + 1];
            for(int i = 0; i < count; i++)
            {
                list[i] = new QArticle(article.Value,m_SaveMax);
            }

            list[count] = new QArticle(article.Value, article.Count % m_SaveMax);

            return list;
        }
    }


    
}
