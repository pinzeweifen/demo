using System.Collections.Generic;
using UnityEngine;

public class StackUI  {

    Stack<BaseUI> stack;

    public StackUI()
    {
        ShowButton.activeChanaged += ShowEvent;
        CloseButton.activeChanaged += CloseEvent;
    }

    ~StackUI()
    {
        ShowButton.activeChanaged -= ShowEvent;
        CloseButton.activeChanaged -= CloseEvent;
    }

    public void Clear()
    {
        stack.Clear();
    }

    private void ShowEvent(BaseUI ui)
    {
        if (ui.isPushStack)
        {
            if (stack.Count > 0)
                stack.Peek().Hide();

            stack.Push(ui);
        }
    }

    private void CloseEvent(BaseUI ui)
    {
        if (ui.isPushStack)
        {
            if (stack.Count > 0)
                stack.Pop().Show();
        }
    }
}
