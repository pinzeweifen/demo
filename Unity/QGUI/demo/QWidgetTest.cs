﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : QWidget {

    public override void Initialization()
    {
        Disabled = false;//关闭键盘和鼠标输入
    }

    protected override void KeyPressEvent(QKeyEvent e)
    {
        Debug.Log(e.Key());
    }

    protected override void KeyReleaseEvent(QKeyEvent e)
    {
        Debug.Log((e.Modifiers() & EventModifiers.Shift )!= 0);
    }

    protected override void MouseClickEvent(QMouseEvent e)
    {
        Debug.Log(e.Pos());
        Debug.Log(e.Globalx());
    }
}
