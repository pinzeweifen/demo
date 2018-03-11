
using QRPG.BehaviourTree;
using System.Collections.Generic;

namespace QRPG.Frame
{
    public partial class QArticleList
    {
        protected List<IArticle> m_List = new List<IArticle>();

        protected EventInfo onAddEvent;
        protected EventInfo onRemoveEvent;

        public IArticle this[int index] { get { return m_List[index]; } }

        public void Add(IArticle article)
        {
            m_List.Add(article);
            if(onAddEvent!=null) onAddEvent(new IndexInfo(m_List.Count - 1));
        }

        public void Insert(int index, IArticle article)
        {
            m_List.Insert(index, article);
            if (onAddEvent != null) onAddEvent(new IndexInfo(index));
        }

        public IArticle RemoveAt(int index)
        {
            if (index < 0 || index >= m_List.Count) return null;

            if (onRemoveEvent != null)
                onRemoveEvent(new IndexInfo(index));

            var value = m_List[index];
            m_List.RemoveAt(index);
            
            return value;
        }
    }
}
