using System.Collections;
using System.Collections.Generic;

namespace QRPG.BehaviourTree
{
    public class BaseNode
    {
        protected INode m_Parent;
        protected List<INode> m_childs = new List<INode>();

        public INode parent { get { return m_Parent; } set { m_Parent = value; } }
        public List<INode> childs { get { return m_childs; } set { m_childs = value; } }

        public virtual void AddNode(INode node) { node.parent = (INode)this; m_childs.Add(node); }
        public virtual void RemoveNode(INode node) { m_childs.Remove(node); }
        public virtual bool HasNode(INode node) { return m_childs.Contains(node); }

        public virtual INode Clone()
        {
            var clone = new BaseNode();
            clone.parent = parent;
            clone.m_childs.AddRange(m_childs);
            return clone as INode;
        }
    }
}
