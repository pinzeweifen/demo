using QRPG.Frame;
using QRPG.BehaviourTree;

public static partial class Actions
{
    private class SetLatticeAction : BaseActionNode
    {
        protected QKnapsackUI m_KnapsackUI;
        protected QUIResources m_Resources;
        protected QAritcleArray m_Knapsack;
        public SetLatticeAction(QKnapsackUI knapsackUI, QUIResources resources, QAritcleArray knapsack)
        {
            m_KnapsackUI = knapsackUI;
            m_Resources = resources;
            m_Knapsack = knapsack;
        }

        public override void OnTick(object input)
        {
            var info = (IndexInfo)input;
            var article = m_Knapsack[info.index];
            if (article != null)
            {
                m_KnapsackUI.SetLatticeArticle(info.index, m_Resources.GetSprite(article.Value.Icon), article.Count);
            }
            else
            {
                m_KnapsackUI.SetLatticeCount(info.index, 0);
            }
        }
    }

    public static INode CreateSetLatticeAction(this QKnapsackUI knapsackUI,QUIResources resources, QAritcleArray knapsack)
    {
        return new SetLatticeAction(knapsackUI, resources, knapsack);
    }
}
