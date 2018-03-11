using System.Collections;
using System.Collections.Generic;

namespace QRPG.BehaviourTree
{
    /// <summary>
    /// for循环节点
    /// </summary>
    public class ForNode : BaseNode, IForNode
    {
        protected int m_From;
        protected int m_To;
        public int from { get { return m_From; } set { m_From = value; } }
        public int to { get {return m_To; } set { m_To = value; } }
        public ForNode(int from, int to)
        {
            m_From = from;
            if (m_To < m_From)
                m_To = m_From;
            else
                m_To = to;
        }
        public virtual void Tick(IEventInfo input)
        {
            for (int j = m_From; j < m_To; j++)
            {
                for (int i = 0; i < childs.Count; i++)
                {
                    childs[i].Tick(input);
                }
            }
        }
        public override INode Clone()
        {
            var clone = base.Clone() as ForNode;
            clone.m_From = m_From;
            clone.m_To = m_To;
            return clone;
        }
    }
}
