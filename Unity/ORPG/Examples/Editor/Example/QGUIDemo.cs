
using UnityEngine;
using UnityEditor;
using QRPG.Database;
using QRPG.Frame;
using System;
using QRPG.GUIEditor;

public partial class QGUIDemo
{
    private void Load()
    {
        QDbAccess db = new QDbAccess(Application.dataPath + "/"+ m_DatabaseName);
        if (CreateTable(db)) return;

        var read = db.Select(m_ArticleType.ToString(), new string[] { "*" });
        while (read.Read())
        {
            var article = ReadDatabase(read);
            m_Dic[article.ID] = article;
            m_LeftList.Add(new LeftItem(article));
        }
        
        db.CloseSqlConnection();
    }

    private void Save()
    {
        QDbAccess db = new QDbAccess(Application.dataPath + "/" + m_DatabaseName);
        CreateTable(db);

        var tableName = m_ArticleType.ToString();

        db.DeleteContents(tableName);
        
        foreach(var item in m_Dic)
        {
            if (item.Value.IsDataNull()) continue;
            db.InsertInto(tableName, WriteDatabase(item.Value));
        }

        db.CloseSqlConnection();
    }

    private bool CreateTable(QDbAccess db)
    {
        if (!db.IsCreateTable(m_ArticleType.ToString()))
        {
            db.CreateTable(m_ArticleType.ToString(), m_ColName, m_ColType, m_KeyIndex, m_NotNull);
            db.CloseSqlConnection();
            return true;
        }
        return false;
    }
}

public partial class QGUIDemo
{
    private static void Create(string Name)
    {
        LeftItem.SetTotal(0);

        var window = GetWindow<QGUIDemo>(Name);
        window.Show();
        window.position = m_DefaultPosition;
    }

    private IQWidget GetItem(int id)
    {
        return ((RightItem)m_RightList[id]).Widget;
    }

    private void RightAdd(IQWidget widget)
    {
        m_RightList.Add(new RightItem(widget));
    }
}

public partial class QGUIDemo
{
    private void OnEnable()
    {
        m_MenuBackround = new QDrawRect(this, m_MenuBackgroundColor);

        m_Button = new QButton(this, Save, m_ButtonName);
        
        m_Line = new QDrawRect(this,m_LineColor);
        m_Line.Move(m_LineInitPosition, m_MenuHeight);
        
        m_Move = new QMoveWidget(this, m_Line);
        m_Move.MinX = m_MoveMinX;
        m_Move.IsMoveY = false;

        m_PrefixLabel = new QPrefixLabel(this, m_PrefixLabelString);
        m_PrefixLabel.Move(0, m_PrefixLableY);
        m_PrefixLabel.Resize(m_PrefixLabelWidth, m_SearchHeight);

        m_Search = new QTextArea(this);
        m_Search.Move(m_SearchX, m_MenuHeight);

        m_LeftList = new QListView(this);
        m_LeftList.onContextMenu += OnLeftListMenu;
        m_LeftList.Move(m_LeftListInitX, m_MenuHeight+m_SearchHeight);

        m_RightList = new QListWidget(this);

        AddToRightList();
        Load();
    }
    
    private void OnGUI()
    {
        var current = Event.current;

        m_MenuBackround.Resize(position.width, m_MenuHeight);
        m_MenuBackround.OnGUI(current);
        
        m_Button.Move(position.width - m_ButtonWidth, 0);
        m_Button.Resize(m_ButtonWidth, m_MenuHeight);
        m_Button.OnGUI(current);

        m_Line.Resize(m_LineWidth, position.height - m_MenuHeight);
        m_Line.OnGUI(current);

        m_Move.MaxX = position.width - m_MoveMaxX;
        m_Move.OnGUI(current);

        m_PrefixLabel.OnGUI(current);

        m_Search.Resize(m_Line.X- m_SearchX, m_SearchHeight);
        m_Search.OnGUI(current);

        #region 搜索字符串
        if (GUI.changed)
        {
            var count = m_LeftList.Count;
            for (int i = 0; i < count; i++)
            {
                if(m_LeftList[i].Name.IndexOf(m_Search.Value)!=-1)
                {
                    m_LeftList.SetIndex(i);break;
                }
            }
        }
        #endregion

        m_LeftList.Resize(m_Line.X, position.height - m_LeftList.GlobalY);
        m_LeftList.OnGUI(current);

        //如果选中左列表 Item
        if (m_LeftList.Index != -1)
        {
            var right = m_Line.X + m_Line.Width;
            m_RightList.Move(right, m_MenuHeight);
            m_RightList.Resize(position.width - right, position.height - m_RightList.GlobalY);

            var item = m_LeftList[m_LeftList.Index];
            if (item!=null)
            {
                var key = (m_LeftList[m_LeftList.Index] as LeftItem).ID;
                if (m_Dic.ContainsKey(key))
                {
                    var article = m_Dic[key];
                    UpdateRightListData(article);
                    m_RightList.OnGUI(current);
                    UpdateDicData(article);
                }
            }
        }
    }
    
    private void OnLeftListMenu(GenericMenu menu,bool isItem)
    {
        menu.AddItem(m_AddItem, false,()=> {
            var item = new LeftItem(m_NewItemName);
            item.onNameChanged = id => { m_Dic[id].SetName(item.Name); };
            m_LeftList.Add(item);
            m_Dic.Add(item.ID, item.Article);
        });

        if (isItem)
        {
            menu.AddItem(m_ModifyItem, false, () => {
                m_LeftList.OpenEditor(m_LeftList.Index);
            });

            menu.AddSeparator("");
            menu.AddItem(m_DeleteItem, false, () => {
                var item = m_LeftList[m_LeftList.Index] as LeftItem;
                m_LeftList.RemoveAt(m_LeftList.Index);
                m_Dic.Remove(item.ID);
            });
        }
    }
    
}

class LeftItem : QViewItem, IQViewItem
{
    private readonly float m_DefaultHeight = 25;

    protected static int m_Total = 0;
    protected int m_ID;

    protected IArticle m_Article;

    public int ID { get { return m_ID; } }
    public IArticle Article { get { return m_Article; } }
    public static int Total { get {return m_Total; } set { if (value > m_Total) m_Total = value; } }

    public Action<int> onNameChanged;

    public LeftItem(string name)
    {
        m_Name = name;
        Height = m_DefaultHeight;

        m_ID = m_Total;
        m_Total++;

        switch (QGUIDemo.m_ArticleType)
        {
            case ArticleType.Consumption:
                m_Article = new Consumption(m_ID, m_Name);
                break;
            case ArticleType.Equipment:
                m_Article = new Equip(m_ID, m_Name);
                break;
            case ArticleType.Stuff:
                m_Article = new Stuff(m_ID, m_Name);
                break;
        }
    }

    public LeftItem(IArticle article)
    {
        m_ID = article.ID;
        m_Name = article.Name;
        m_Article = article;
        Height = m_DefaultHeight;
        Total = m_ID;
    }

    public static void SetTotal(int value)
    {
        m_Total = value;
    }

    protected override void NameChangedEvent()
    {
        if (onNameChanged != null) onNameChanged(m_ID);
    }
}

class RightItem : QViewItem, IQViewItem
{
    private readonly float m_DefaultHeight = 16;

    protected IQWidget m_Widget;

    public IQWidget Widget { get { return m_Widget; } }

    public RightItem(IQWidget widget)
    {
        m_Widget = widget;
        Height = m_DefaultHeight;
    }

    public override void Update(Rect rect)
    {
        m_Widget.OnGUI(Event.current, rect);
    }
}