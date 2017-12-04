using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class QEditorListView : QAbstractEditorWindow
{
    private int i;
    private Vector2 scrollPos;          //滚动条坐标
    private int index = -1;             //当前选择索引
    private bool isDrag = false;        //是否可以拖动
    private bool isEditor = false;      //是否可以编辑
    private int endDragIndex = -1;      //最后拖动的索引
    private int doubleClickIndex = -1;  //双击索引
    private List<string> list = new List<string>();//保存的所有值

    private static bool drag = false;           //是否拖动
    private static QEditorListView startView;   //开始拖动的列表对象
    private static string select = "LODSliderRangeSelected";//选择时的样式
    private static string about = "HelpBox";//默认样式

    public Action<int ,int> IndexChangedEvent;
    public Action<int> EditorIndexEvent;
    public Action<int> StartDragEvent;
    public Action<QEditorListView, QEditorListView> EndDragEvent;//结束拖动事件
    
    public QEditorListView(EditorWindow window) : base(window) { }

    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    public bool IsEditor
    {
        get { return isEditor; }
        set { isEditor = value; }
    }

    public bool IsDrag
    {
        get { return isDrag; }
        set { isDrag = value; }
    }
    
    public int EndDragIndex
    {
        get { return endDragIndex; }
    }
    
    public int DoubleClickIndex
    {
        get { return doubleClickIndex; }
        set { doubleClickIndex = value; }
    }

    public string this[int index]
    {
        get { return list[index]; }
        set { list[index] = value; }
    }

    public override void Update()
    {
        scrollPos = QEditorLayout.ScrollView(() => {
            for (i = 0; i < list.Count; i++)
            {
                QEditorLayout.Horizontal(x =>
                {
                    if (doubleClickIndex != i)
                    {
                        EditorGUILayout.LabelField(list[i]);
                        SelectEvent(x);
                        if (isEditor) EditorEvent(x);
                        if (isDrag) DragEvent(x);
                    }
                    else
                    {
                        list[doubleClickIndex] = EditorGUILayout.TextArea(list[doubleClickIndex]);
                    }
                }, i == index ? select : about);
            }
        }, scrollPos);
        
    }

    public void Add(string value)
    {
        list.Add(value);
    }

    public void Adds(string[] list)
    {
        for(int i = 0; i < list.Length; i++)
        {
            this.list.Add(list[i]);
        }
    }

    public void RemoveAt(int index)
    {
        list.RemoveAt(index);
    }

    public void RemoveAll()
    {
        list.Clear();
    }

    private void SelectEvent(Rect x)
    {
        if (QEditorEvent.IsMouseDown() && x.Contains(QEditorEvent.MousePosition()))
        {
            if (doubleClickIndex != -1)
                doubleClickIndex = -1;
            else
            {
                if (IndexChangedEvent != null)
                    IndexChangedEvent(index, i);
                index = i;
            }
                
            w.Repaint();
            if (drag) drag = false;
        }
    }

    private void EditorEvent(Rect x)
    {
        if (QEditorEvent.IsDoubleClick() && x.Contains(QEditorEvent.MousePosition()))
        {
            doubleClickIndex = i;
            if (EditorIndexEvent != null)
                EditorIndexEvent(doubleClickIndex);
        }
    }

    private void DragEvent(Rect x)
    {
        if (!drag && QEditorEvent.IsMouseDrag() && x.Contains(QEditorEvent.MousePosition()))
        {
            drag = true;
            startView = this;
            if (StartDragEvent != null) StartDragEvent(i);
        }
        if (drag && QEditorEvent.IsMouseUp() && x.Contains(QEditorEvent.MousePosition()))
        {
            endDragIndex = i;
            if (EndDragEvent != null)
                EndDragEvent(startView, this);

            if (IndexChangedEvent != null)
                IndexChangedEvent(index, i);
            index = i;

            w.Repaint();
            drag = false;
            endDragIndex = -1;
            startView = null;
        }
    }
}
