using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFrame
{
    public class Stuff : Article, IArticle
    {
        public Stuff()
        {
        }

        public Stuff(int id, string name) : base(id, name)
        {
        }
    }
}
