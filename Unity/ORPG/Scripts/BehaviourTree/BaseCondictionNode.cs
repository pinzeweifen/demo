using System.Collections;
using System.Collections.Generic;

namespace QRPG.BehaviourTree
{
    /// <summary>
    /// 基本条件节点
    /// </summary>
    public class BaseCondictionNode
    {
        protected INode m_Parent;
        protected INode m_TrueNode;
        protected INode m_FalseNode;
        protected List<ICondition> m_Condictions = new List<ICondition>();

        public List<ICondition> conditions { get { return m_Condictions; } set { m_Condictions = value; } }
        public INode parent { get { return m_Parent; } set { m_Parent = value; } } 
        public INode trueNode { get { return m_TrueNode; } set { m_TrueNode = value; } }
        public INode falseNode { get { return m_FalseNode; } set { m_FalseNode = value; } }

        public virtual void AddCondition(ICondition node) { m_Condictions.Add(node); }
        public virtual void RemoveCondition(ICondition node) { m_Condictions.Remove(node); }
        public virtual bool HasCondition(ICondition node) { return m_Condictions.Contains(node); }

        public virtual INode Clone()
        {
            var clone = new BaseCondictionNode();
            clone.parent = m_Parent;
            clone.trueNode = m_TrueNode;
            clone.falseNode = m_FalseNode;
            clone.m_Condictions.AddRange(m_Condictions);
            return clone as INode;
        }
    }
}
