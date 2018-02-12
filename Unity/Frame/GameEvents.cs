using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace frame
{
    /// <summary>
    /// 游戏事件
    /// </summary>
    class GameEvents
    {
        /// <summary>
        /// 单位死亡事件
        /// </summary>
        public static Action<Unit> OnDeath;

        /// <summary>
        /// 获得物品事件
        /// </summary>
        public static Action<Article> OnKnapsackAdd;

        /// <summary>
        /// 任务开始
        /// </summary>
        public static Action<int> OnTaskStart;

        /// <summary>
        /// 任务更新
        /// </summary>
        public static Action<int> OnTaskUpdate;

        /// <summary>
        /// 任务结束
        /// </summary>
        public static Action<int> OnTaskEnd;

        /// <summary>
        /// 任务放弃
        /// </summary>
        public static Action<int> OnTaskRenounce;
    }
}
