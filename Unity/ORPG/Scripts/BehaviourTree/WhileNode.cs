using System.Collections;
using System.Collections.Generic;

namespace QRPG.BehaviourTree
{
    /// <summary>
    /// while循环节点
    /// </summary>
    public class WhileNode : BaseNode, IWhileNode
    {
        protected int m_Frequency;
        public int frequency { get { return m_Frequency; } set { m_Frequency = value; } }
        public WhileNode(int count) { m_Frequency = count; }
        public virtual void Tick(IEventInfo input)
        {
            int tmp = m_Frequency;
            while (tmp-- != 0)
            {
                for (int i = 0; i < childs.Count; i++)
                {
                    childs[i].Tick(input);
                }
            }
        }
        public override INode Clone()
        {
            var clone = base.Clone() as WhileNode;
            clone.m_Frequency = m_Frequency;
            return clone;
        }
    }
}
