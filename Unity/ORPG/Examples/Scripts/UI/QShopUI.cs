using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRPG.Frame;

public class QShopUI : QBaseWindow
{
    private static QShopUI m_Instance;
    public static QShopUI Instance { get { return m_Instance; } }

    protected struct Item
    {
        public int Index;
        public int Count;
    };

    public QShopItemUI m_ItemPrefab;

    protected List<Item> m_Emptions = new List<Item>();
    protected List<QShopItemUI> m_List = new List<QShopItemUI>();

    protected override void Initialise()
    {
        m_Instance = this;
    }

    public void Add(int index,Sprite sprite, string name)
    {
        var item = Instantiate(m_ItemPrefab);
        item.Index = index;
        item.Icon = sprite;
        item.Name = name;
        m_List.Add(item);
    }

    public void AddToshoppingCart(int index, int count)
    {
        m_Emptions.Add(new Item{ Index=index,Count=count});
    }
}