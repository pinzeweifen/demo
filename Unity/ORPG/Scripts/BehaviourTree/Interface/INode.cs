using System;
using System.Collections.Generic;


namespace QRPG.BehaviourTree
{
    public interface INode
    {
        void Tick(IEventInfo info);
        INode parent { get; set; }
        INode Clone();
    }
}
