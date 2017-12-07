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
        setPosSize();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        Disabled = disabled;
        parent = rectTr.parent.GetComponent<QWidget>();
        localPos = new Vector2(rectTr.anchoredPosition.x, -rectTr.anchoredPosition.y);
        
        EventListener.Get(gameObject).onEnter += e => {
            ShowCursor(QEnum.Type.Enter);
            enterEvent(new QEnterEvent());
        };
        EventListener.Get(gameObject).onExit += e => {
            ShowCursor(QEnum.Type.Exit);
            leaveEvent(new QExitEvent());
        };
        EventListener.Get(gameObject).onMouseDown += e => {
            CreateMouseEvent(QEnum.Type.MouseButtonPress, QEnum.GetMouseButton(e.button));
        };
        EventListener.Get(gameObject).onMouseUp += e => {
            CreateMouseEvent(QEnum.Type.MouseButtonRelease, QEnum.GetMouseButton(e.button));
        };
        EventListener.Get(gameObject).onClick += e =>{
            var click = new QMouseEvent(QEnum.Type.MouseButtonClick, QEnum.GetMouseButton(e.button), mouseLocalPos(), mouseScreenPos());
            mouseClickEvent(click);
        };
        EventListener.Get(gameObject).onDoubleClick += e => {
            var click = new QMouseEvent(QEnum.Type.MouseButtonDblClick, QEnum.GetMouseButton(e.button), mouseLocalPos(), mouseScreenPos());
            mouseDoubleClickEvent(click);
        };

        EventListener.Get(gameObject).onBeginDrag += e => {
            ShowCursor(QEnum.Type.DragLeave);
            dragLeaveEvent(new QDragEvent(mouseLocalPos(), mouseScreenPos()));
        };
        EventListener.Get(gameObject).onDrag += e => {
            if (!isDrag)
                mouseMoveEvent(new QMouseEvent(QEnum.Type.MouseMove, QEnum.GetMouseButton(e.button), mouseLocalPos(), mouseScreenPos()));
            else
                dragMoveEvent(new  QDragMoveEvent(mouseLocalPos(), mouseScreenPos()));
        };
        EventListener.Get(gameObject).onDrop += e => {
            dropEvent(new QDropEvent(mouseLocalPos(), mouseScreenPos()));
        };
        EventListener.Get(gameObject).onEndDrag += e => {
            ShowCursor(QEnum.Type.DragEnd);
            dragEndEvent(new QDragEndEvent(mouseLocalPos(), mouseScreenPos()));
        };
        EventListener.Get(gameObject).onScroll += e => {
            wheelEvent(new QWheelEvent(e.scrollDelta));
        };
        EventListener.Get(gameObject).onSelect += e => {
            isSelect = true;
            focusInEvent(new QFocusEvent(QEnum.Type.FocusIn));
        };
        EventListener.Get(gameObject).onDeselect += e => {
            isSelect = false;
            focusOutEvent(new QFocusEvent(QEnum.Type.FocusOut));
        };

        Initialization();
    }

    public virtual void Initialization() { }
    protected virtual void closeEvent(QCloseEvent e) { }
    protected virtual void mouseMoveEvent(QMouseEvent e) { }
    protected virtual void mousePressEvent(QMouseEvent e) { }
    protected virtual void mouseReleaseEvent(QMouseEvent e) { }
    protected virtual void mouseClickEvent(QMouseEvent e) { }
    protected virtual void mouseDoubleClickEvent(QMouseEvent e) { }
    protected virtual void enterEvent(QEnterEvent e) { }
    protected virtual void leaveEvent(QExitEvent e) { }
    protected virtual void dragLeaveEvent(QDragEvent e) { }
    protected virtual void dragMoveEvent(QDragMoveEvent e) { }
    protected virtual void dropEvent(QDropEvent e) { }
    protected virtual void dragEndEvent(QDragEndEvent e) { }
    protected virtual void wheelEvent(QWheelEvent e) { }
    protected virtual void keyPressEvent(QKeyEvent e) { }
    protected virtual void keyReleaseEvent(QKeyEvent e) { }
    protected virtual void showEvent(QShowEvent e) { }
    protected virtual void resizeEvent(QResizeEvent e) { }
    protected virtual void moveEvent(QMoveEvent e) { }
    protected virtual void hideEvent(QHideEvent e) { }
    protected virtual void focusInEvent(QFocusEvent e) { }
    protected virtual void focusOutEvent(QFocusEvent e) { }
    protected virtual void paintEvent() { }

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
            keyPressEvent(new QKeyEvent(QEnum.Type.KeyPress, currentEvent.keyCode, currentEvent.modifiers));
            isKeyDown = false;
        }
        if(isSelect && currentEvent.type == EventType.KeyUp && currentEvent.keyCode != KeyCode.None)
        {
            keyReleaseEvent(new QKeyEvent(QEnum.Type.KeyRelease, currentEvent.keyCode, currentEvent.modifiers));
        }
        paintEvent();
    }

    public Vector2 size()
    {
        return rectTr.sizeDelta;
    }

    /// <summary>
    /// 相对坐标
    /// </summary>
    /// <returns></returns>
    public Vector2 pos()
    {
        return localPos;
    }

    /// <summary>
    /// 绝对坐标
    /// </summary>
    /// <returns></returns>
    public Vector2 globalPos()
    {
        return new Vector2(transform.position.x, Screen.height - transform.position.y) - posSize;
    }

    public void show()
    {
        gameObject.SetActive(true);
        showEvent(new QShowEvent());
    }

    public void hide()
    {
        gameObject.SetActive(false);
        hideEvent(new QHideEvent());
    }

    public void close()
    {
        closeEvent(new QCloseEvent());
        Destroy(gameObject);
    }

    public void showMaximized()
    {
        normalSize = size();
        normalPos = transform.position;

        resize(Screen.width, Screen.height);
        transform.position = posSize;
        maximized = true;
    }

    public void showNormal()
    {
        resize(normalSize.x, normalSize.y);
        transform.position = normalPos;
    }

    public void lower()
    {
        rectTr.SetAsLastSibling();
    }

    public void resize(float width, float height)
    {
        var oldSize = rectTr.sizeDelta;
        rectTr.sizeDelta = new Vector2(width, height);
        resizeEvent(new QResizeEvent( rectTr.sizeDelta,oldSize));
        setPosSize();
    }

    public void move(float x, float y)
    {
        var old = rectTr.anchoredPosition;
        localPos = new Vector2(x, y);
        rectTr.anchoredPosition = new Vector2(x, -y);
        moveEvent(new QMoveEvent(rectTr.anchoredPosition,old));
    }

    public void setHidden(bool hidden)
    {
        setVisible(!hidden);
    }
    
    public void setGeometry(float x, float y, float width, float height)
    {
        move(x, y);
        resize(width, height);
    }
    
    public void setDisabled(bool disabled)
    {
        this.disabled = disabled;
    }
    
    public void setFocus()
    {
        EventListener.SetFocus(gameObject);
    }

    public virtual void setEnabled(bool enabled)
    {
        Qenabled = enabled;
    }

    public virtual void setVisible(bool visible)
    {
        if (visible)
            show();
        else
            hide();
    }

    public bool isModal()
    {
        return modal;
    }

    public bool isEnabled()
    {
        return Qenabled;
    }

    public bool isDisabled()
    {
        return disabled;
    }

    public bool isMaximized()
    {
        return maximized;
    }

    public bool Visible()
    {
        return gameObject.activeSelf;
    }
    
    private void setPosSize()
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
            case QEnum.Type.Enter:cursor.show();break;
            case QEnum.Type.Exit:cursor.hide();break;
            case QEnum.Type.MouseButtonPress:
            case QEnum.Type.DragLeave:
                cursor.setState(QEnum.CursorState.Down);break;
            case QEnum.Type.MouseButtonRelease:
            case QEnum.Type.DragEnd:
                cursor.setState(QEnum.CursorState.Hover); break;
        }
    }

    private void CreateMouseEvent(QEnum.Type type, QEnum.MouseButton button)
    {
        var mouseEvent = new QMouseEvent(type, button, mouseLocalPos(), mouseScreenPos());

        switch (type)
        {
            case QEnum.Type.MouseButtonPress:
                ShowCursor(type);
                mousePressEvent(mouseEvent);
                break;
            case QEnum.Type.MouseButtonRelease:
                ShowCursor(type);
                mouseReleaseEvent(mouseEvent);
                break;
        }
    }

    private Vector2 mouseScreenPos()
    {
        return new Vector2(Input.mousePosition.x, -(Input.mousePosition.y - Screen.height));
    }

    private Vector2 mouseLocalPos()
    {
        return mouseScreenPos() - globalPos();
    }
}
