using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRPG.Frame;

public class Consumption : Article, IConsumption
{
    public Consumption()
    {
    }

    public Consumption(int id, string name) : base(id, name)
    {
    }
}