﻿using UnityEngine.EventSystems;

public class QEnum {
    public enum CursorState
    {
        Hover,
        Down
    }
    public enum MouseButton
    {
        NoButton,
        LeftButton,
        RightButton,
        MiddleButton
    }
    public enum Type
    {
        Hide,
        Show,
        Move,
        Resize,
        Close,

        FocusIn,
        FocusOut,

        Enter,
        Exit,

        HoverEnter,
        HoverLeave,
        HoverMove,

        KeyPress,
        KeyRelease,

        MouseButtonClick,
        MouseButtonDblClick,
        MouseButtonPress,
        MouseButtonRelease,
        MouseMove,

        Wheel,

        DragLeave,
        DragMove,
        DragEnd,
        Drop
    }

    public static MouseButton GetMouseButton(PointerEventData.InputButton button)
    {
        switch (button)
        {
            case PointerEventData.InputButton.Left:
                return MouseButton.LeftButton;
            case PointerEventData.InputButton.Right:
                return MouseButton.RightButton;
            case PointerEventData.InputButton.Middle:
                return MouseButton.MiddleButton;
        }
        return MouseButton.NoButton;
    }
}
