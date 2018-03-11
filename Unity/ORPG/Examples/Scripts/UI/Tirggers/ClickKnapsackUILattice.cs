using QRPG.Frame;
using QRPG.BehaviourTree;

public partial class QKnapsackUI
{
    private class ClickLatticeEvent : QTirgger
    {
        QKnapsackUI m_KnapsackUI;
        public override void Logout() { m_KnapsackUI.onClickLattice -= Function; }
        public override void Register() { m_KnapsackUI.onClickLattice += Function; }
        public ClickLatticeEvent(QKnapsackUI knapsackUI, INode function, string name = "", string annotation = "") : base(function, name, annotation)
        {
            m_KnapsackUI = knapsackUI;
        }
    }

    public QTirgger CreateClickEventTirgger(INode function, string name = "", string annotation = "")
    {
        return new ClickLatticeEvent(this, function, name, annotation);
    }
}

