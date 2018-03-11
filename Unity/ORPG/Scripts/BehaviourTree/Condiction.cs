using System.Collections;
using System.Collections.Generic;

namespace QRPG.BehaviourTree
{
    /// <summary>
    /// 条件节点
    /// </summary>
    public class Condiction : BaseCondictionNode, IConditionNode
    {
        public Condiction(ICondition func) { m_Condictions.Add(func); }

        public void Tick(IEventInfo input)
        {
            for (int i = 0; i < m_Condictions.Count; i++)
            {
                if (!m_Condictions[i].ExternalCondition(input))
                {
                    if (m_FalseNode != null) m_FalseNode.Tick(input);
                    return;
                }
            }

            if (m_TrueNode != null) m_TrueNode.Tick(input);
        }
    }
}
