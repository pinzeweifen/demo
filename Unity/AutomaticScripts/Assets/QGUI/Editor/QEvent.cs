using UnityEngine;
using UnityEditor;
using System;

namespace QGUI
{
    public enum MouseButton
    {
        Left=0,
        Right,
        Middle
    }

    public static class QEvent
    {
        #region public function
        
        /// <summary>
        /// 粘贴命令
        /// </summary>
        /// <param name="callback"></param>
        public static void CommandPaste(this Event current, Action callback)
        {
            current.Command("Paste", callback);
        }

        /// <summary>
        /// 复制命令
        /// </summary>
        /// <param name="callback"></param>
        public static void CommandCopy(this Event current, Action callback)
        {
            current.Command("Copy", callback);
        }

        /// <summary>
        /// 剪切命令
        /// </summary>
        /// <param name="callback"></param>
        public static void CommandCut(this Event current, Action callback)
        {
            current.Command("Cut", callback);
        }

        /// <summary>
        /// 删除命令
        /// </summary>
        /// <param name="callback"></param>
        public static void CommandDelete(this Event current, Action callback)
        {
            current.Command("Delete", callback);
        }

        /// <summary>
        /// 定位到选定目标物体命令
        /// </summary>
        /// <param name="callback"></param>
        public static void CommandFrameSelected(this Event current, Action callback)
        {
            current.Command("FrameSelected", callback);
        }

        /// <summary>
        /// 克隆命令
        /// </summary>
        /// <param name="callback"></param>
        public static void CommandDuplicate(this Event current, Action callback)
        {
            current.Command("Duplicate", callback);
        }

        /// <summary>
        /// 选择所有命令
        /// </summary>
        /// <param name="callback"></param>
        public static void CommandSelectAll(this Event current, Action callback)
        {
            current.Command("SelectAll", callback);
        }
        
        /// <summary>
        /// 是否按下事件
        /// </summary>
        /// <returns></returns>
        public static bool IsKeyDown(this Event current)
        {
            return current.type == EventType.keyDown;
        }

        /// <summary>
        /// 是否弹起事件
        /// </summary>
        /// <returns></returns>
        public static bool IsKeyUp(this Event current)
        {
            return current.type == EventType.KeyUp;
        }

        /// <summary>
        /// 是否双击事件
        /// </summary>
        /// <returns></returns>
        public static bool IsDoubleClick(this Event current)
        {
            return current.clickCount == 2;
        }

        /// <summary>
        /// 是否右键事件
        /// </summary>
        /// <returns></returns>
        public static bool IsContextClick(this Event current)
        {
            return current.type == EventType.ContextClick;
        }

        /// <summary>
        /// 是否按下鼠标事件
        /// </summary>
        /// <returns></returns>
        public static bool IsMouseDown(this Event current)
        {
            return current.type == EventType.mouseDown;
        }

        /// <summary>
        /// 是否弹起鼠标事件
        /// </summary>
        /// <returns></returns>
        public static bool IsMouseUp(this Event current)
        {
            return current.type == EventType.mouseUp;
        }

        /// <summary>
        /// 是否移动鼠标事件
        /// </summary>
        /// <returns></returns>
        public static bool IsMouseMove(this Event current)
        {
            return current.type == EventType.mouseMove;
        }

        /// <summary>
        /// 是否滚轮事件
        /// </summary>
        /// <returns></returns>
        public static bool IsScrollWhell(this Event current)
        {
            return current.type == EventType.ScrollWheel;
        }

        /// <summary>
        /// 是否拖拽事件
        /// </summary>
        /// <returns></returns>
        public static bool IsDrag(this Event current)
        {
            return current.type == EventType.mouseDrag;
        }

        /// <summary>
        /// 是否拖放事件
        /// </summary>
        /// <returns></returns>
        public static bool IsDragPerform(this Event current)
        {
            if (current.type == EventType.DragPerform
              || current.type == EventType.DragUpdated)
            {
                if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 是否拖拽结束事件
        /// </summary>
        /// <returns></returns>
        public static bool IsDragEnd(this Event current)
        {
            return current.type == EventType.DragExited;
        }

        /// <summary>
        /// 是否布局事件
        /// </summary>
        /// <returns></returns>
        public static bool IsLayout(this Event current)
        {
            return current.type == EventType.Layout;
        }

        /// <summary>
        /// 是否在矩形内双击事件
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool IsDoubleClick(this Event current, Rect rect)
        {
            if (!current.IsDoubleClick()) return false;
            return current.IsRectContains(rect);
        }

        /// <summary>
        /// 是否在矩形内按下事件
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool IsContextClick(this Event current, Rect rect)
        {
            if (!current.IsContextClick()) return false;
            return current.IsRectContains(rect);
        }

        /// <summary>
        /// 是否在矩形内拖拽事件
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool IsMouseDrag(this Event current, Rect rect)
        {
            if (!current.IsDrag()) return false;
            return current.IsRectContains(rect);
        }

        /// <summary>
        /// 是否在矩形内按下鼠标事件
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool IsMouseDown(this Event current, Rect rect)
        {
            if (!current.IsMouseDown()) return false;
            return current.IsRectContains(rect);
        }

        /// <summary>
        /// 是否在矩形内弹起鼠标事件
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool IsMouseUp(this Event current, Rect rect)
        {
            if (!current.IsMouseUp()) return false;
            return current.IsRectContains(rect);
        }

        /// <summary>
        /// 是否在矩形内移动鼠标事件
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool IsMouseMove(this Event current, Rect rect)
        {
            if (!current.IsMouseMove()) return false;
            return current.IsRectContains(rect);
        }

        /// <summary>
        /// 是否在矩形内滚动事件
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool IsScrollWhell(this Event current, Rect rect)
        {
            if (!current.IsScrollWhell()) return false;
            return current.IsRectContains(rect);
        }

        /// <summary>
        /// 是否在矩形内拖放事件
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool IsDragPerform(this Event current, Rect rect)
        {
            if ((current.type == EventType.DragPerform
              || current.type == EventType.DragUpdated)
              && current.IsRectContains(rect))
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 是否在矩形内结束拖拽事件
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static bool IsDragEnd(this Event current, Rect rect)
        {
            if (!current.IsDragEnd()) return false;
            return current.IsRectContains(rect);
        }

        /// <summary>
        /// 获得滚动值
        /// </summary>
        /// <returns></returns>
        public static float GetScrollDelta(this Event current)
        {
            return current.delta.y;
        }

        /// <summary>
        /// 是否按下 Key 事件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyCode(this Event current,KeyCode key)
        {
            return current.keyCode == key;
        }

        public static bool IsModifiers(this Event current, EventModifiers modifiers)
        {
            return current.modifiers == modifiers;
        }

        /// <summary>
        /// 是否按下鼠标按钮
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        public static bool IsButton(this Event current,MouseButton button)
        {
            return current.button == (int)button;
        }

        public static bool IsRectContains(this Event current, Rect rect)
        {
            return rect.Contains(current.mousePosition);
        }

        #endregion

        #region private function
        
        private static void Command(this Event current, string command, Action callback)
        {
            if (null == callback) return;
            if (current.type == EventType.ValidateCommand && current.commandName == command)
            {
                callback();
                current.Use();
            }
        }


        #endregion
    }

}

