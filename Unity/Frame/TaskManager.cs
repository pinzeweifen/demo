using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frame
{
    /// <summary>
    /// 任务管理
    /// </summary>
    public class TaskManager
    {
        private Dictionary<int, Task> dic = new Dictionary<int, Task>();

        public Task this[int key]
        {
            get { return dic[key]; }
        }

        public bool Add(Task task)
        {
            if (dic.ContainsKey(task.GetID))
                return true;

            dic[task.GetID] = task;
            return false;
        }
        
        public void Remove(int task)
        {
            if (dic.ContainsKey(task))
                dic.Remove(task);
        }

        /// <summary>
        /// 接受任务
        /// </summary>
        /// <param name="task"></param>
        public bool Accept(int task)
        {
            if (dic.ContainsKey(task))
               return dic[task].Start();
            return false;
        }

        /// <summary>
        /// 完成任务
        /// </summary>
        /// <param name="task"></param>
        public bool Submit(int task)
        {
            if (dic.ContainsKey(task))
                return dic[task].Submit();
            return false;
        }

        /// <summary>
        /// 放弃任务
        /// </summary>
        /// <param name="task"></param>
        public bool Renounce(int task)
        {
            if (dic.ContainsKey(task))
                 return dic[task].Renounce();
            return false;
        }
    }
}
