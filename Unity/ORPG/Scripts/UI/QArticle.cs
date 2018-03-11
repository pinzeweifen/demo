
namespace QRPG.Frame
{
    public class QArticle
    {
        protected int m_Count;
        protected IArticle m_Article;

        public QArticle()
        {
        }

        public QArticle(IArticle article, int count)
        {
            m_Article = article;
            m_Count = count;
        }

        public int Count
        {
            get { return m_Count; }
            set { m_Count =value; }
        }

        public IArticle Value
        {
            get { return m_Article; }
        }

        public QArticle Clone()
        {
            var clone = new QArticle(m_Article, m_Count);
            return clone;
        }
    }
}
