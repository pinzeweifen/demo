using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ValueMonitor<T>  {

    T value;
    Action<T> valueChanged;

    public T Value
    {
        get { return value; }
        set
        {
            this.value = value;
            if(valueChanged!=null)
                valueChanged(value);
        }
    }

    public void AddListener(Action<T> call)
    {
        valueChanged += call;
    }

    public void Remove(Action<T> call)
    {
        valueChanged -= call;
    }
    
}
