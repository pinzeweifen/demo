using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFrame
{
    public class Equip : Article, IArticle
    {
        public Equip()
        {
        }

        public Equip(int id, string name) : base(id, name)
        {
        }
    }
}
