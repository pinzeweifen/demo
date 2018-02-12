using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frame
{
    /// <summary>
    /// 击杀任务
    /// </summary>
    public class StrikeKillTask : Task
    {
        private int count;
        private int maxCount;

        public StrikeKillTask(int id, Award ward, OperatorOperation accept, OperatorOperation update, OperatorOperation complete, State state = State.CannotAccept) : base(id, ward, accept, update, complete, state)
        {
        }

        protected override void OnStart()
        {
            count = 0;
            GameEvents.OnDeath += OnDeath;
        }

        protected override bool OnUpdate()
        {
            if (count < maxCount)
            {
                count++;
                if(count == maxCount)
                {
                    state = State.CompleteTask;
                }
                return true;
            }
            return false;
        }
        
        protected override bool OnSubmit()
        {
            //是否可以获得物品
            if (completeOperation.IsTrue(count))
            {
                GameEvents.OnDeath -= OnDeath;
                return true;
            }
            return false;
        }

        protected override void OnRenounce()
        {
            GameEvents.OnDeath -= OnDeath;
        }

        private void OnDeath(Unit unit)
        {
            //是否可以更新
            if (updateOperation.IsTrue(unit))
            {
                Update();
            }
        }
    }
}
