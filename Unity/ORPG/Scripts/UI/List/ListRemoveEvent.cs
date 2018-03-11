using QRPG.BehaviourTree;

namespace QRPG.Frame
{
    public partial class QArticleList
    {
        private class RemoveEvent : QTirgger
        {
            QArticleList m_List;
            public RemoveEvent(QArticleList list, INode function, string name = "", string annotation = "") : base(function, name, annotation)
            {
                m_List = list;
            }

            public override void Logout()
            {
                m_List.onRemoveEvent -= Function;
            }

            public override void Register()
            {
                m_List.onRemoveEvent += Function;
            }
        }

        public QTirgger CreateRemoveEventTirgger(INode function, string name = "", string annotation = "")
        {
            return new RemoveEvent(this, function, name, annotation);
        }
    }
}
