using System.Collections;
using UnityEngine;

namespace QRPG.BehaviourTree
{
    /// <summary>
    /// 等待
    /// </summary>
    public class WaitNode : BaseNode, IWaitNode
    {
        protected float m_Timer;
        public float timer { get {return m_Timer; } set { m_Timer = value; } }
        public WaitNode(float timer) { m_Timer = timer; }
        public void Tick(IEventInfo info)
        {
            WaitObject.Instance.AddCoroutine(m_Timer, Wait,info);
        }
        
        private void Wait(IEventInfo info)
        {
            for (int i = 0; i < childs.Count; i++)
            {
                childs[i].Tick(info);
            }
        }
        public override INode Clone()
        {
            var clone = base.Clone() as WaitNode;
            clone.m_Timer = m_Timer;
            return clone;
        }
    }

    public class WaitObject : MonoBehaviour
    {
        private static WaitObject m_Instance;

        public static WaitObject Instance
        {
            get
            {
                return m_Instance ?? (m_Instance = new GameObject("WaitObject").GetComponent<WaitObject>());
            }
        }

        public void AddCoroutine(float wait, EventInfo action, IEventInfo info)
        {
            StartCoroutine(Wait(wait, action,info));
        }

        IEnumerator Wait(float wait, EventInfo action,IEventInfo info)
        {
            yield return new WaitForSeconds(wait);
            action(info);
        }
    }
}
