
using QRPG.BehaviourTree;

namespace QRPG.Frame
{
    public partial class QArticleList
    {
        private class AddEvent : QTirgger
        {
            QArticleList m_List;
            public AddEvent(QArticleList list,INode function, string name = "", string annotation = "") : base(function, name, annotation)
            {
                m_List = list;
            }

            public override void Logout()
            {
                m_List.onAddEvent -= Function;
            }

            public override void Register()
            {
                m_List.onAddEvent += Function;
            }
        }

        public QTirgger CreateAddEventTirgger(INode function, string name = "", string annotation = "")
        {
            return new AddEvent(this,function,name,annotation);
        }
    }
}
