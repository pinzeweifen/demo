
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Database;
using QFrame;
using System;
using QGUI;

public partial class Demo : EditorWindow
{
    public static ArticleType    m_ArticleType = ArticleType.Consumption;
    private static readonly Rect m_DefaultPosition = new Rect(200, 100, 850, 750);

    private readonly float       m_MenuHeight = 20;
    private readonly Color       m_MenuBackgroundColor = new Color(1, 1, 1);

    private readonly Color       m_LineColor = new Color32(0, 150, 0, 255);
    private readonly float       m_LineInitPosition = 200;
    private readonly float       m_LineWidth = 3;

    private readonly float       m_ButtonWidth = 50;
    private readonly string      m_ButtonName = "保存";

    private readonly float       m_MoveMinX = 100;
    private readonly float       m_MoveMaxX = 280;

    private readonly string      m_PrefixLabelString = "搜索：";
    private readonly float       m_PrefixLabelWidth = 30;
    private readonly float       m_PrefixLableY = 22;

    private readonly float       m_SearchHeight = 20;
    private readonly float       m_SearchX = 35;

    private readonly float       m_LeftListInitX = 0;

    private readonly string      m_NewItemName = "new Article";
    private readonly GUIContent  m_AddItem = new GUIContent("新建自定义物品");
    private readonly GUIContent  m_ModifyItem = new GUIContent("重命名自定义物品");
    private readonly GUIContent  m_DeleteItem = new GUIContent("删除自定义物品");

    private readonly string      m_DatabaseName = "article";
    private readonly int         m_KeyIndex = 0;
    private readonly string[]    m_ColName = new string[] {
        "ID","Name","Icon","Price"
    };
    private readonly DataType[]  m_ColType = new DataType[] {
        DataType.INTEGER,DataType.TEXT,DataType.TEXT,DataType.INTEGER
    };
    private readonly int[]      m_NotNull = new int[] { 0, 1, 2, 3 };

    private QButton      m_Button;
    private QMoveWidget  m_Move;
    private QDrawRect    m_MenuBackround;
    private QDrawRect    m_Line;
    private QPrefixLabel m_PrefixLabel;
    private QTextArea    m_Search;
    private QListView    m_LeftList;
    private QListWidget  m_RightList;
    private Dictionary<int, IArticle> m_Dic = new Dictionary<int, IArticle>();
}

public partial class Demo
{
    /// <summary>
    /// 向右边列表添加 Item
    /// </summary>
    private void AddToRightList()
    {
        RightAdd(new QLabelField(this, "ID"));
        RightAdd(new QLabelField(this, "Name"));
        RightAdd(new QSpriteField(this, "Icon"));
        RightAdd(new QIntField(this, "Price"));
    }

    /// <summary>
    /// 列表信息切换为左边列表所选中的物品
    /// </summary>
    /// <param name="article"></param>
    private void UpdateRightListData(IArticle article)
    {
        //索引对应添加时的索引
        GetItem(0).ToLabelField().Value = article.ID.ToString();
        GetItem(1).ToLabelField().Value = article.Name;
        GetItem(2).ToSpriteField().SetValue(article.Icon);
        GetItem(3).ToIntField().Value = article.Price;
    }

    /// <summary>
    /// 更新物品信息
    /// </summary>
    /// <param name="article"></param>
    private void UpdateDicData(IArticle article)
    {
        article.SetIcon(GetItem(2).ToSpriteField().GetValue());
        article.SetPrice(GetItem(3).ToIntField().Value);
    }

    /// <summary>
    /// 读取数据库
    /// </summary>
    /// <param name="read"></param>
    /// <returns></returns>
    private IArticle ReadDatabase(Mono.Data.Sqlite.SqliteDataReader read)
    {
        IArticle article = null;
        switch (m_ArticleType)
        {
            case ArticleType.Consumption: article = new Consumption(read.GetInt32(0), read.GetString(1)); break;
            case ArticleType.Equipment: article = new Equip(read.GetInt32(0), read.GetString(1)); break;
            case ArticleType.Stuff: article = new Stuff(read.GetInt32(0), read.GetString(1)); break;
        }
        article.SetIcon(read.GetString(2));
        article.SetPrice(read.GetInt32(3));

        return article;
    }

    /// <summary>
    /// 写入数据库
    /// </summary>
    /// <param name="article"></param>
    /// <returns></returns>
    private string[] WriteDatabase(IArticle article)
    {
        return new string[] { article.ID.ToString(), article.Name, article.Icon, article.Price.ToString() };
    }
}

public partial class Demo
{
    private void Load()
    {
        DbAccess db = new DbAccess(Application.dataPath + "/"+ m_DatabaseName);
        if (CreateTable(db)) return;

        var read = db.Select(m_ArticleType.ToString(), new string[] { "*" });
        while (read.Read())
        {
            var article = ReadDatabase(read);
            m_Dic[article.ID] = article;
            m_LeftList.Add(new LeftItem(article));
        }
        LeftItem.Total++;
        db.CloseSqlConnection();
    }

    private void Save()
    {
        DbAccess db = new DbAccess(Application.dataPath + "/" + m_DatabaseName);
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

    private bool CreateTable(DbAccess db)
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

public partial class Demo
{
    [MenuItem("QGUI/Consumption")]
    private static void CreateConsumption()
    {
        m_ArticleType = ArticleType.Consumption;
        Create(m_ArticleType.ToString());
    }

    [MenuItem("QGUI/Equip")]
    private static void CreateEquip()
    {
        m_ArticleType = ArticleType.Equipment;
        Create(m_ArticleType.ToString());
    }
    
    [MenuItem("QGUI/Stuff")]
    private static void CreateStuff()
    {
        m_ArticleType = ArticleType.Stuff;
        Create(m_ArticleType.ToString());
    }

    private static void Create(string Name)
    {
        var window = GetWindow<Demo>(Name);
        window.Show();
        window.position = m_DefaultPosition;
    }

    private IWidget GetItem(int id)
    {
        return ((RightItem)m_RightList[id]).Widget;
    }

    private void RightAdd(IWidget widget)
    {
        m_RightList.Add(new RightItem(widget));
    }
}

public partial class Demo
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

    int index;
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

            var article = m_Dic[ (m_LeftList[m_LeftList.Index] as LeftItem).ID];
            UpdateRightListData(article);
            m_RightList.OnGUI(current);
            UpdateDicData(article);
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

            menu.AddItem(m_DeleteItem, false, () => {
                m_LeftList.RemoveAt(m_LeftList.Index);
            });
        }
    }
    
}

class LeftItem : QViewItem, IViewItem
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

        switch (Demo.m_ArticleType)
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
        m_Total = m_ID > m_Total ? m_ID : m_Total;
    }

    protected override void NameChangedEvent()
    {
        if (onNameChanged != null) onNameChanged(m_ID);
    }
}

class RightItem : QViewItem, IViewItem
{
    private readonly float m_DefaultHeight = 16;

    protected IWidget m_Widget;

    public IWidget Widget { get { return m_Widget; } }

    public RightItem(IWidget widget)
    {
        m_Widget = widget;
        Height = m_DefaultHeight;
    }

    public override void Update(Rect rect)
    {
        m_Widget.OnGUI(Event.current, rect);
    }
}