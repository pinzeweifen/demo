
namespace QFrame
{
    public class Article
    {
        protected int m_Id;
        protected int m_Price;
        protected string m_Name;
        protected string m_Icon=string.Empty;
        
        public int ID { get { return m_Id; } }
        public int Price { get { return m_Price; } }
        public string Name { get { return m_Name; } }
        public string Icon { get { return m_Icon; } }
        
        public Article(int id, string name)
        {
            m_Id = id;
            m_Name = name;
        }

        public void SetID(int id)
        {
            m_Id = id;
        }

        public void SetName(string name)
        {
            m_Name = name;
        }

        public void SetIcon(string icon)
        {
            m_Icon = icon;
        }

        public void SetPrice(int price)
        {
            m_Price = price;
        }

        public bool IsDataNull()
        {
            if (m_Name == null) return true;
            if (m_Icon == null) return true;
            return false;
        }
    }

    public enum ArticleType
    {
        /// <summary>
        /// 消耗品
        /// </summary>
        Consumption,
        /// <summary>
        /// 材料
        /// </summary>
        Stuff,
        /// <summary>
        /// 装备
        /// </summary>
        Equipment
    }
}