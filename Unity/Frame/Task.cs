using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frame
{
    /// <summary>
    /// 任务
    /// </summary>
    public abstract partial class Task
    {
        private int id;
        protected State state;

        protected Award ward;
        protected OperatorOperation acceptOperation;
        protected OperatorOperation updateOperation;
        protected OperatorOperation completeOperation;

        public int GetID
        {
            get { return id; }
        }

        public Task(int id,Award ward,OperatorOperation accept,OperatorOperation update,OperatorOperation complete, State state = State.CannotAccept)
        {
            this.id = id;
            this.ward = ward;
            acceptOperation = accept;
            updateOperation = update;
            completeOperation = complete;

            if (state ==  State.DoTasking)
                OnStart();
        }

        /// <summary>
        /// 是否可以接任务
        /// </summary>
        /// <returns></returns>
        public bool IsAccept()
        {
            return acceptOperation.IsTrue();
        }
        
        public bool Start()
        {
            if (state == State.CanAccept)
                return true;
            
            OnStart();
            state = State.DoTasking;

            if (GameEvents.OnTaskStart != null)
                GameEvents.OnTaskStart(id);

            return false;
        }
        
        public bool Submit()
        {
            if(state != State.CompleteTask)
                return true;

            if (OnSubmit())
            {
                ward.Provide();
                state = State.FinishTask;

                if (GameEvents.OnTaskEnd != null)
                    GameEvents.OnTaskEnd(id);
            }
            
            return false;
        }
        
        public bool Renounce()
        {
            if (state != State.DoTasking)
                return true;
            
            OnRenounce();
            state = State.CanAccept;

            if (GameEvents.OnTaskRenounce != null)
                GameEvents.OnTaskRenounce(id);
            return false;
        }

        protected void Update()
        {
            if (OnUpdate())
            {
                if (GameEvents.OnTaskUpdate != null)
                    GameEvents.OnTaskUpdate(id);
            }
        }

        /// <summary>
        /// 开始任务
        /// </summary>
        protected abstract void OnStart();

        /// <summary>
        /// 更新任务
        /// </summary>
        protected abstract bool OnUpdate();

        /// <summary>
        /// 完成任务
        /// </summary>
        protected abstract bool OnSubmit();
        
        /// <summary>
        /// 放弃任务
        /// </summary>
        protected abstract void OnRenounce();
    }

    public abstract partial class Task
    {
        public enum State
        {
            /// <summary>
            /// 不可接取
            /// </summary>
            CannotAccept,

            /// <summary>
            /// 可接取
            /// </summary>
            CanAccept,

            /// <summary>
            /// 任务进行中
            /// </summary>
            DoTasking,

            /// <summary>
            /// 完成未领奖
            /// </summary>
            CompleteTask,

            /// <summary>
            /// 完成已领取奖励
            /// </summary>
            FinishTask
        }
    }
}
