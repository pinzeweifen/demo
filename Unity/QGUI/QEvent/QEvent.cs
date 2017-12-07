﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QEvent  {

    private QEnum.Type t;

    public QEvent(QEnum.Type type)
    {
        t = type;
    }

    public QEnum.Type type()
    {
        return t;
    }
}

public class QEnterEvent : QEvent
{
    public QEnterEvent(QEnum.Type type = QEnum.Type.Enter) : base(type) { }
}

public class QExitEvent : QEvent
{
    public QExitEvent(QEnum.Type type = QEnum.Type.Exit) : base(type) { }
}

public class QMouseEvent : QEvent
{
    private QEnum.MouseButton b;
    private Vector2 l;
    private Vector2 s;

    public QMouseEvent(QEnum.Type type, Vector2 localPos, Vector2 screenPos):base(type)
    {
        l = localPos;
        s = screenPos;
    }
    public QMouseEvent(QEnum.Type type, QEnum.MouseButton button, Vector2 localPos, Vector2 screenPos) : base(type)
    {
        b = button;
        l = localPos;
        s = screenPos;
    }

    public virtual QEnum.MouseButton button() { return b; }
    public Vector2 pos() { return l; }
    public float x() { return l.x; }
    public float y() { return l.y; }
    public Vector2 globalPos() { return s; }
    public float globalx() { return s.x; }
    public float globaly() { return s.y; }
}

public class QDragEvent : QMouseEvent
{
    protected static QEnum.MouseButton b;
    protected static object dropData;

    public QDragEvent(Vector2 localPos, Vector2 screenPos, QEnum.Type type = QEnum.Type.DragLeave) 
        : base(type, localPos, screenPos) { }

    public QDragEvent(object data, QEnum.MouseButton button, Vector2 localPos, Vector2 screenPos, QEnum.Type type = QEnum.Type.DragLeave) 
        : base(type, localPos,screenPos)
    {
        dropData = data;
        b = button;
    }

    public override QEnum.MouseButton button() { return b; }
}

public class QDragMoveEvent : QMouseEvent
{
    public QDragMoveEvent(Vector2 localPos, Vector2 screenPos, QEnum.Type type=QEnum.Type.DragMove) 
        : base(type,localPos, screenPos) { }
}

public class QDropEvent : QDragEvent
{
    public QDropEvent(Vector2 localPos, Vector2 screenPos, QEnum.Type type = QEnum.Type.Drop) 
        : base(localPos, screenPos, type) { }
    public object data() { return dropData; }
}

public class QDragEndEvent : QMouseEvent
{
    public QDragEndEvent(Vector2 localPos, Vector2 screenPos, QEnum.Type type = QEnum.Type.DragEnd) 
        : base(type, localPos, screenPos) { }
}

public class QWheelEvent : QEvent
{
    private int d;
    public QWheelEvent(Vector2 delta, QEnum.Type type=QEnum.Type.Wheel) : base(type)
    {
        d = (int)delta.y;
    }

    public int delta() { return d; }
}

public class QResizeEvent : QEvent
{
    private Vector2 s,o;
    public QResizeEvent(Vector2 size, Vector2 oldSize, QEnum.Type type = QEnum.Type.Resize) : base(type)
    {
        s = size;
        o = oldSize;
    }

    public Vector2 size() { return s; }
    public Vector2 oldSize() { return o; }
}

public class QShowEvent : QEvent
{
    public QShowEvent(QEnum.Type type = QEnum.Type.Show) : base(type) { }
}

public class QHideEvent : QEvent
{
    public QHideEvent(QEnum.Type type = QEnum.Type.Hide) : base(type) { }
}

public class QCloseEvent : QEvent
{
    public QCloseEvent(QEnum.Type type = QEnum.Type.Close) : base(type) { }
}

public class QMoveEvent : QEvent
{
    private Vector2 s, o;
    public QMoveEvent(Vector2 size, Vector2 oldSize, QEnum.Type type = QEnum.Type.Move) : base(type)
    {
        s = size;
        o = oldSize;
    }
    public Vector2 size() { return s; }
    public Vector2 oldSize() { return o; }
}

public class QFocusEvent : QEvent
{
    public QFocusEvent(QEnum.Type type) : base(type) { }
}

public class QKeyEvent : QEvent
{
    private KeyCode k;
    private EventModifiers m;
    public QKeyEvent(QEnum.Type type, KeyCode keyCode, EventModifiers modifiers) : base(type)
    {
        k = keyCode;
        m = modifiers;
    }
    public KeyCode key() { return k; }
    public EventModifiers modifiers() { return m; }
}
