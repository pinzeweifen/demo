﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : QWidget {

    public override void Initialization()
    {
        Disabled = false;//关闭键盘和鼠标输入
    }

    protected override void keyPressEvent(QKeyEvent e)
    {
        Debug.Log(e.key());
    }

    protected override void keyReleaseEvent(QKeyEvent e)
    {
        Debug.Log((e.modifiers() & EventModifiers.Shift )!= 0);
    }

    protected override void mouseClickEvent(QMouseEvent e)
    {
        Debug.Log(e.pos());
        Debug.Log(e.globalx());
    }
}
