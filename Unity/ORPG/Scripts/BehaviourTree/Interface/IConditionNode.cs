using System;
using System.Collections.Generic;


namespace QRPG.BehaviourTree
{
    public interface ICondition
    {
        bool ExternalCondition(IEventInfo info);
    }

    /// <summary>
    /// 条件节点
    /// </summary>
    public interface IConditionNode : INode
    {
        INode trueNode { get; set; }
        INode falseNode { get; set; }
        List<ICondition> conditions { get; set; }
        void AddCondition(ICondition node);
        void RemoveCondition(ICondition node);
        bool HasCondition(ICondition node);
    }
}
