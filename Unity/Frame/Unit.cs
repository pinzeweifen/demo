using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frame
{
    /// <summary>
    /// 游戏单位
    /// </summary>
    public abstract class Unit
    {
        private string m_Name;
        public int Hp
        {
            get;
        }
        
        public string Name
        {
            get { return m_Name; }
        }

        private void Death()
        {
            if (GameEvents.OnDeath!=null)
                GameEvents.OnDeath(this);
            OnDeate();
        }
        protected abstract void OnDeate();
    }
}
