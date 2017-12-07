﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class QWidget : MonoBehaviour
{

    [Tooltip("是否最大化")]
    public bool maximized = false;
    [Tooltip("是否模态")]
    public bool modal = false;
    [Tooltip("是否激活，在不同部件将会有不同变化，例如QPushButton将会变灰并且无法点击")]
    public bool Qenabled = true;
    [Tooltip("是否禁用输入")]
    public bool disabled = false;
    [Tooltip("如果不设置鼠标将会使用默认值")]
    public QCursor cursor;
    
    protected QWidget parent;

    private bool isKeyDown = false;
    private bool isDrag = false;
    private Vector2 normalSize;
    private Vector2 normalPos;
    private Vector2 posSize;
    private Vector2 localPos;
    private RectTransform rectTr;
    private CanvasGroup canvasGroup;

    public bool Disabled
    {
        get { return canvasGroup.blocksRaycasts; }
        set {
            canvasGroup.blocksRaycasts = !value;
        }
    }

    private void Awake()
    {
        rectTr = (RectTransform)transform;
        SetPosSize();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        Disabled = disabled;
        parent = rectTr.parent.GetComponent<QWidget>();
        localPos = new Vector2(rectTr.anchoredPosition.x, -rectTr.anchoredPosition.y);
        
        EventListener.Get(gameObject).onEnter += e => {
            ShowCursor(QEnum.Type.Enter);
            EnterEvent(new QEnterEvent());
        };
        EventListener.Get(gameObject).onExit += e => {
            ShowCursor(QEnum.Type.Exit);
            LeaveEvent(new QExitEvent());
        };
        EventListener.Get(gameObject).onMouseDown += e => {
            CreateMouseEvent(QEnum.Type.MouseButtonPress, QEnum.GetMouseButton(e.button));
        };
        EventListener.Get(gameObject).onMouseUp += e => {
            CreateMouseEvent(QEnum.Type.MouseButtonRelease, QEnum.GetMouseButton(e.button));
        };
        EventListener.Get(gameObject).onClick += e =>{
            var click = new QMouseEvent(QEnum.Type.MouseButtonClick, QEnum.GetMouseButton(e.button), mouseLocalPos(), MouseScreenPos());
            MouseClickEvent(click);
        };
        EventListener.Get(gameObject).onDoubleClick += e => {
            var click = new QMouseEvent(QEnum.Type.MouseButtonDblClick, QEnum.GetMouseButton(e.button), mouseLocalPos(), MouseScreenPos());
            MouseDoubleClickEvent(click);
        };

        EventListener.Get(gameObject).onBeginDrag += e => {
            ShowCursor(QEnum.Type.DragLeave);
            DragLeaveEvent(new QDragEvent(mouseLocalPos(), MouseScreenPos()));
        };
        EventListener.Get(gameObject).onDrag += e => {
            if (!isDrag)
                MouseMoveEvent(new QMouseEvent(QEnum.Type.MouseMove, QEnum.GetMouseButton(e.button), mouseLocalPos(), MouseScreenPos()));
            else
                DragMoveEvent(new  QDragMoveEvent(mouseLocalPos(), MouseScreenPos()));
        };
        EventListener.Get(gameObject).onDrop += e => {
            DropEvent(new QDropEvent(mouseLocalPos(), MouseScreenPos()));
        };
        EventListener.Get(gameObject).onEndDrag += e => {
            ShowCursor(QEnum.Type.DragEnd);
            DragEndEvent(new QDragEndEvent(mouseLocalPos(), MouseScreenPos()));
        };
        EventListener.Get(gameObject).onScroll += e => {
            WheelEvent(new QWheelEvent(e.scrollDelta));
        };
        EventListener.Get(gameObject).onSelect += e => {
            isSelect = true;
            FocusInEvent(new QFocusEvent(QEnum.Type.FocusIn));
        };
        EventListener.Get(gameObject).onDeselect += e => {
            isSelect = false;
            FocusOutEvent(new QFocusEvent(QEnum.Type.FocusOut));
        };

        Initialization();
    }

    public virtual void Initialization() { }
    protected virtual void CloseEvent(QCloseEvent e) { }
    protected virtual void MouseMoveEvent(QMouseEvent e) { }
    protected virtual void MousePressEvent(QMouseEvent e) { }
    protected virtual void MouseReleaseEvent(QMouseEvent e) { }
    protected virtual void MouseClickEvent(QMouseEvent e) { }
    protected virtual void MouseDoubleClickEvent(QMouseEvent e) { }
    protected virtual void EnterEvent(QEnterEvent e) { }
    protected virtual void LeaveEvent(QExitEvent e) { }
    protected virtual void DragLeaveEvent(QDragEvent e) { }
    protected virtual void DragMoveEvent(QDragMoveEvent e) { }
    protected virtual void DropEvent(QDropEvent e) { }
    protected virtual void DragEndEvent(QDragEndEvent e) { }
    protected virtual void WheelEvent(QWheelEvent e) { }
    protected virtual void KeyPressEvent(QKeyEvent e) { }
    protected virtual void KeyReleaseEvent(QKeyEvent e) { }
    protected virtual void ShowEvent(QShowEvent e) { }
    protected virtual void ResizeEvent(QResizeEvent e) { }
    protected virtual void MoveEvent(QMoveEvent e) { }
    protected virtual void HideEvent(QHideEvent e) { }
    protected virtual void FocusInEvent(QFocusEvent e) { }
    protected virtual void FocusOutEvent(QFocusEvent e) { }
    protected virtual void PaintEvent() { }

    private bool isSelect = false;
    private void FixedUpdate()
    {
        if (!Disabled) return;

        if (Input.anyKeyDown && isSelect)
        {
            isKeyDown = true;
        }
    }
    
    private Event currentEvent;
    private void OnGUI()
    {
        if (!Disabled) return;

        currentEvent = Event.current;
        if (isKeyDown && currentEvent.keyCode != KeyCode.None)
        {
            KeyPressEvent(new QKeyEvent(QEnum.Type.KeyPress, currentEvent.keyCode, currentEvent.modifiers));
            isKeyDown = false;
        }
        if(isSelect && currentEvent.type == EventType.KeyUp && currentEvent.keyCode != KeyCode.None)
        {
            KeyReleaseEvent(new QKeyEvent(QEnum.Type.KeyRelease, currentEvent.keyCode, currentEvent.modifiers));
        }
        PaintEvent();
    }

    public Vector2 Size()
    {
        return rectTr.sizeDelta;
    }

    /// <summary>
    /// 相对坐标
    /// </summary>
    /// <returns></returns>
    public Vector2 Pos()
    {
        return localPos;
    }

    /// <summary>
    /// 绝对坐标
    /// </summary>
    /// <returns></returns>
    public Vector2 GlobalPos()
    {
        return new Vector2(transform.position.x, Screen.height - transform.position.y) - posSize;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        ShowEvent(new QShowEvent());
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        HideEvent(new QHideEvent());
    }

    public void Close()
    {
        CloseEvent(new QCloseEvent());
        Destroy(gameObject);
    }

    public void ShowMaximized()
    {
        normalSize = Size();
        normalPos = transform.position;

        Resize(Screen.width, Screen.height);
        transform.position = posSize;
        maximized = true;
    }

    public void ShowNormal()
    {
        Resize(normalSize.x, normalSize.y);
        transform.position = normalPos;
    }

    public void Lower()
    {
        rectTr.SetAsLastSibling();
    }

    public void Resize(float width, float height)
    {
        var oldSize = rectTr.sizeDelta;
        rectTr.sizeDelta = new Vector2(width, height);
        ResizeEvent(new QResizeEvent( rectTr.sizeDelta,oldSize));
        SetPosSize();
    }

    public void Move(float x, float y)
    {
        var old = rectTr.anchoredPosition;
        localPos = new Vector2(x, y);
        rectTr.anchoredPosition = new Vector2(x, -y);
        MoveEvent(new QMoveEvent(rectTr.anchoredPosition,old));
    }

    public void SetHidden(bool hidden)
    {
        SetVisible(!hidden);
    }
    
    public void SetGeometry(float x, float y, float width, float height)
    {
        Move(x, y);
        Resize(width, height);
    }
    
    public void SetDisabled(bool disabled)
    {
        this.disabled = disabled;
    }
    
    public void SetFocus()
    {
        EventListener.SetFocus(gameObject);
    }

    public virtual void SetEnabled(bool enabled)
    {
        Qenabled = enabled;
    }

    public virtual void SetVisible(bool visible)
    {
        if (visible)
            Show();
        else
            Hide();
    }

    public bool IsModal()
    {
        return modal;
    }

    public bool IsEnabled()
    {
        return Qenabled;
    }

    public bool IsDisabled()
    {
        return disabled;
    }

    public bool IsMaximized()
    {
        return maximized;
    }

    public bool Visible()
    {
        return gameObject.activeSelf;
    }
    
    private void SetPosSize()
    {
        posSize = new Vector2(
            rectTr.sizeDelta.x * rectTr.pivot.x,
            rectTr.sizeDelta.y * (1-rectTr.pivot.y)
        );
    }

    private void ShowCursor(QEnum.Type type)
    {
        if (cursor == null) return;

        switch (type)
        {
            case QEnum.Type.Enter:cursor.Show();break;
            case QEnum.Type.Exit:cursor.Hide();break;
            case QEnum.Type.MouseButtonPress:
            case QEnum.Type.DragLeave:
                cursor.SetState(QEnum.CursorState.Down);break;
            case QEnum.Type.MouseButtonRelease:
            case QEnum.Type.DragEnd:
                cursor.SetState(QEnum.CursorState.Hover); break;
        }
    }

    private void CreateMouseEvent(QEnum.Type type, QEnum.MouseButton button)
    {
        var mouseEvent = new QMouseEvent(type, button, mouseLocalPos(), MouseScreenPos());

        switch (type)
        {
            case QEnum.Type.MouseButtonPress:
                ShowCursor(type);
                MousePressEvent(mouseEvent);
                break;
            case QEnum.Type.MouseButtonRelease:
                ShowCursor(type);
                MouseReleaseEvent(mouseEvent);
                break;
        }
    }

    private Vector2 MouseScreenPos()
    {
        return new Vector2(Input.mousePosition.x, -(Input.mousePosition.y - Screen.height));
    }

    private Vector2 mouseLocalPos()
    {
        return MouseScreenPos() - GlobalPos();
    }
}
