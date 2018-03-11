using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRPG.Frame;

public class Equip : Article, IEquip
{
    public Equip()
    {
    }

    public Equip(int id, string name) : base(id, name)
    {
    }
}
