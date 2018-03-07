using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Database;
using QFrame;
using QGUI;

public partial class Demo : EditorWindow
{
    public static ArticleType m_ArticleType = ArticleType.Consumption;
    private static readonly Rect m_DefaultPosition = new Rect(200, 100, 850, 750);

    private readonly float m_MenuHeight = 20;
    private readonly Color m_MenuBackgroundColor = new Color(1, 1, 1);

    private readonly Color m_LineColor = new Color32(0, 150, 0, 255);
    private readonly float m_LineInitPosition = 200;
    private readonly float m_LineWidth = 3;

    private readonly float m_ButtonWidth = 50;
    private readonly string m_ButtonName = "保存";

    private readonly float m_MoveMinX = 100;
    private readonly float m_MoveMaxX = 280;

    private readonly string m_PrefixLabelString = "搜索：";
    private readonly float m_PrefixLabelWidth = 30;
    private readonly float m_PrefixLableY = 22;

    private readonly float m_SearchHeight = 20;
    private readonly float m_SearchX = 35;

    private readonly float m_LeftListInitX = 0;

    private readonly string m_NewItemName = "new Article";

    private readonly string m_DatabaseName = "article";
    private readonly int m_KeyIndex = 0;

    private static string[] m_ColName;
    private static DataType[] m_ColType;
    private static int[] m_NotNull;

    private static GUIContent m_AddItem;
    private static GUIContent m_ModifyItem;
    private static GUIContent m_DeleteItem;

    private QButton m_Button;
    private QMoveWidget m_Move;
    private QDrawRect m_MenuBackround;
    private QDrawRect m_Line;
    private QPrefixLabel m_PrefixLabel;
    private QTextArea m_Search;
    private QListView m_LeftList;
    private QListWidget m_RightList;
    private Dictionary<int, IArticle> m_Dic = new Dictionary<int, IArticle>();
}

public partial class Demo
{
    [MenuItem("QGUI/Consumption")]
    private static void CreateConsumption()
    {
        m_ArticleType = ArticleType.Consumption;
        m_AddItem = new GUIContent("新建自定义消耗品");
        m_ModifyItem = new GUIContent("重命名自定义消耗品");
        m_DeleteItem = new GUIContent("删除自定义消耗品");
        m_ColName = new string[] { "ID", "Name", "Icon", "Price" };
        m_ColType = new DataType[] { DataType.INTEGER, DataType.TEXT, DataType.TEXT, DataType.INTEGER };
        m_NotNull = new int[] { 0, 1, 2, 3 };
        Create(m_ArticleType.ToString());
    }

    [MenuItem("QGUI/Equip")]
    private static void CreateEquip()
    {
        m_ArticleType = ArticleType.Equipment;
        m_AddItem = new GUIContent("新建自定义装备");
        m_ModifyItem = new GUIContent("重命名自定义装备");
        m_DeleteItem = new GUIContent("删除自定义装备");
        m_ColName = new string[] { "ID", "Name", "Icon", "Price" };
        m_ColType = new DataType[] { DataType.INTEGER, DataType.TEXT, DataType.TEXT, DataType.INTEGER };
        m_NotNull = new int[] { 0, 1, 2, 3 };
        Create(m_ArticleType.ToString());
    }

    [MenuItem("QGUI/Stuff")]
    private static void CreateStuff()
    {
        m_ArticleType = ArticleType.Stuff;
        m_AddItem = new GUIContent("新建自定义材料");
        m_ModifyItem = new GUIContent("重命名自定义材料");
        m_DeleteItem = new GUIContent("删除自定义材料");
        m_ColName = new string[] { "ID", "Name", "Icon", "Price" };
        m_ColType = new DataType[] { DataType.INTEGER, DataType.TEXT, DataType.TEXT, DataType.INTEGER };
        m_NotNull = new int[] { 0, 1, 2, 3 };
        Create(m_ArticleType.ToString());
    }

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
        var tmp = article.Icon.Remove(0, article.Icon.IndexOf("Resources/") + 10);
        tmp = tmp.Remove(tmp.LastIndexOf('.'));
        return new string[] { article.ID.ToString(), article.Name, tmp, article.Price.ToString() };
    }
}