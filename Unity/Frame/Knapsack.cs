using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frame
{
    public abstract class Knapsack
    {
        public void Add(Article article)
        {
            if (GameEvents.OnKnapsackAdd != null)
                GameEvents.OnKnapsackAdd(article);
            OnAdd(article);
        }

        protected abstract void OnAdd(Article article);
    }
}
