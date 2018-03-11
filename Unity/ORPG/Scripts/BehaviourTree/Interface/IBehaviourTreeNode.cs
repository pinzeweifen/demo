using System;
using System.Collections.Generic;

namespace QRPG.BehaviourTree
{
    /// <summary>
    /// 行为树节点
    /// </summary>
    public interface IBehaviourTreeNode : INode
    {
        List<INode> childs { get; set; }
        void AddNode(INode node);
        void RemoveNode(INode node);
        bool HasNode(INode node);
    }
}
