using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Item : AbstractItem
{
    protected override void SetCount()
    {
        Count = ((Article)Article).count;
    }

    protected override void SetIcon()
    {
        Icon = Resources.Load<Sprite>(((Article)Article).icon);
    }

    protected override string ArticleToString()
    {
        var tmp = (Article)Article;
        StringBuilder sb = new StringBuilder();
        sb.Append("path:"+tmp.icon+'\n');
        sb.Append("count:" + tmp.count);
        return sb.ToString();
    }
}

public class Article
{
    public string icon;
    public int count;

    public Article(string icon, int count)
    {
        this.icon = icon;
        this.count = count;
    }
}
