using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRPG.Frame;

public class Stuff : Article, IStuff
{
    public Stuff()
    {
    }

    public Stuff(int id, string name) : base(id, name)
    {
    }
}

