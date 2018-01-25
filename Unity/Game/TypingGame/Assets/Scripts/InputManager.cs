using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public Color32 color;

    public Action NextLevelEvent;
    public Action CompleteWordEvent;

    private void Awake()
    {
        stringColor = string.Format("{0:X2}{1:X2}{2:X2}", color.r, color.g, color.b);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLevelEvent();
        }
    }

    private Item current;
    private int key;
    private List<Item> list;
    private int endIndex;
    private string originalString;
    private string stringColor;
    private void OnGUI()
    {
        if(QGUIEvent.IsKeyDown() && !QGUIEvent.GetKeyCode(KeyCode.None))
        {
            if (current == null)
            {
                key = (int)QGUIEvent.GetKeyCode() - 'a';
                if (key >= 0 && key < 26)
                {
                    list = ItemManager.list[key];
                    if (list.Count > 0)
                    {
                        current = list[0];
                        if(current.Word.Length != 1)
                        {
                            originalString = current.Word;
                            current.Word = string.Format("{0}{1}{2}{3}", "<color=#" + stringColor + ">",
                            originalString[0], "</color>", originalString.Substring(1));
                            endIndex = 1;
                        }
                        else
                        {
                            DeleteItem();
                        }
                    }
                }
            }
            else
            {
                if(current != null)
                {
                    if ((int)QGUIEvent.GetKeyCode() == originalString[endIndex])
                    {
                        endIndex++;
                        if (endIndex != originalString.Length)
                        {
                            current.Word = string.Format(
                            "{0}{1}{2}{3}",
                            "<color=#" + stringColor + ">",
                            originalString.Remove(endIndex),
                            "</color>",
                            originalString.Substring(endIndex));
                        }
                        else
                        {
                            DeleteItem();
                        }
                    }
                }
            }
        }
    }

    private void DeleteItem()
    {
        list.RemoveAt(0);
        current.Delete();
        CompleteWordEvent();
    }
}
