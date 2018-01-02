using UnityEngine;
using UnityEditor;
using System;

public enum Mouse
{
    Left,
    Middle,
    Right
}

public class QEditorEvent
{
    #region public function

    public static void Use()
    {
        Event.current.Use();
    }

    public static Vector2 Dalta()
    {
        return Event.current.delta;
    }

    public static bool ScrollWhellDalta()
    {
        return Dalta().y > 0 ? true : false;
    }

    public static Vector2 MousePosition()
    {
        return Event.current.mousePosition;
    }

    public static void CommandPaste(Action callback)
    {
        Command("Paste", callback);
    }

    public static void CommandCopy(Action callback)
    {
        Command("Copy", callback);
    }

    public static void CommandCut(Action callback)
    {
        Command("Cut", callback);
    }

    public static void CommandDelete(Action callback)
    {
        Command("Delete", callback);
    }

    public static void CommandFrameSelected(Action callback)
    {
        Command("FrameSelected", callback);
    }

    public static void CommandDuplicate(Action callback)
    {
        Command("Duplicate", callback);
    }

    public static void CommandSelectAll(Action callback)
    {
        Command("SelectAll", callback);
    }

    public static bool IsKeyDown()
    {
        return Event.current.type == EventType.keyDown;
    }
    
    public static bool IsKeyUp()
    {
        return Event.current.type == EventType.KeyUp;
    }

    public static bool IsDoubleClick()
    {
        return Event.current.clickCount == 2;
    }
    
    public static bool IsContextClick()
    {
        return Event.current.type == EventType.ContextClick;
    }

    public static bool IsMouseDown()
    {
        return Event.current.type == EventType.mouseDown;
    }

    public static bool IsMouseUp()
    {
        return Event.current.type == EventType.mouseUp;
    }

    public static bool IsMouseMove()
    {
        return Event.current.type == EventType.mouseMove;
    }

    public static bool IsScrollWhell()
    {
        return Event.current.type == EventType.ScrollWheel;
    }

    public static bool IsMouseDrag()
    {
        return Event.current.type == EventType.mouseDrag;
    }

    public static bool IsDragPerform()
    {
        if (Event.current.type == EventType.DragPerform
          || Event.current.type == EventType.DragUpdated)
        {
            DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
            if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
                return true;
        }

        return false;
    }

    public static bool IsDragEnd()
    {
        return Event.current.type == EventType.DragExited;
    }

    public static bool IsLayout()
    {
        return Event.current.type == EventType.Layout;
    }

    public static bool IsDoubleClick(Rect rect)
    {
        if (!IsDoubleClick()) return false;
        return IsRectContains(rect);
    }

    public static bool IsContextClick(Rect rect)
    {
        if (!IsContextClick()) return false;
        return IsRectContains(rect);
    }

    public static bool IsMouseDrag(Rect rect)
    {
        if (!IsMouseDrag()) return false;
        return IsRectContains(rect);
    }

    public static bool IsMouseDown(Rect rect)
    {
        if (!IsMouseDown()) return false;
        return IsRectContains(rect);
    }

    public static bool IsMouseUp(Rect rect)
    {
        if (!IsMouseUp()) return false;
        return IsRectContains(rect);
    }

    public static bool IsMouseMove(Rect rect)
    {
        if (!IsMouseMove()) return false;
        return IsRectContains(rect);
    }

    public static bool IsScrollWhell(Rect rect)
    {
        if (!IsScrollWhell()) return false;
        return IsRectContains(rect);
    }
    
    public static bool IsDragPerform(Rect rect)
    {
        if ((Event.current.type == EventType.DragPerform
          || Event.current.type == EventType.DragUpdated)
          && rect.Contains(Event.current.mousePosition))
        {
            DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
            if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
                return true;
        }
        return false;
    }

    public static bool IsDragEnd(Rect rect)
    {
        if (!IsDragEnd()) return false;
        return IsRectContains(rect);
    }

    public static float GetScrollDelta()
    {
        return Event.current.delta.y;
    }

    public static bool GetKeyCode(KeyCode key)
    {
        return Event.current.keyCode == key;
    }

    public static Mouse GetButton()
    {
        return (Mouse)Event.current.button;
    }

    public static Vector2 GetMousePosition()
    {
        return Event.current.mousePosition;
    }

    #endregion

    #region private function

    private static bool IsRectContains(Rect rect)
    {
        return rect.Contains(Event.current.mousePosition);
    }

    private static void Command(string command, Action callback)
    {
        if (null == callback) return;
        if (Event.current.type == EventType.ValidateCommand && Event.current.commandName == command)
        {
            callback();
            Event.current.Use();
        }
    }


    #endregion
}
