using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFrame
{
    public class Consumption : Article, IArticle
    {
        public Consumption()
        {
        }

        public Consumption(int id, string name) : base(id, name)
        {
        }
    }
}
