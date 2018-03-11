using QRPG.BehaviourTree;

namespace QRPG.Frame
{
    public partial class QAritcleArray
    {
        private class UpdateEvent : QTirgger
        {
            QAritcleArray m_List;
            public override void Logout() { m_List.onUpdate -= Function; }
            public override void Register() { m_List.onUpdate += Function; }
            public UpdateEvent(QAritcleArray list, INode function, string name = "", string annotation = "") : base(function, name, annotation)
            {
                m_List = list;
            }
        }

        public QTirgger CreateUpdateEventTirgger(INode function, string name = "", string annotation = "")
        {
            return new UpdateEvent(this, function, name, annotation);
        }
    }
}
