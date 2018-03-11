using System.Collections;
using System.Collections.Generic;

namespace QRPG.BehaviourTree
{
    /// <summary>
    /// 基本动作节点
    /// </summary>
    public abstract class BaseActionNode : BaseNode, IActionNode
    {
        public virtual void Tick(IEventInfo input)
        {
            OnTick(input);
            for (int i = 0; i < childs.Count; i++)
            {
                childs[i].Tick(input);
            }
        }
        public abstract void OnTick(object input);
    }
}
