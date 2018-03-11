using System;
using System.Collections.Generic;
using QRPG.Database;
using UnityEngine;
using QRPG.Frame;


public class QDataResources
{
    private static QDataResources m_Instance;
    public static QDataResources Instance { get { return m_Instance ?? (m_Instance = new QDataResources()); } }

    protected Dictionary<int, IArticle> m_Equips = new Dictionary<int, IArticle>();
    protected Dictionary<int, IArticle> m_Consums = new Dictionary<int, IArticle>();
    protected Dictionary<int, IArticle> m_Stuffs = new Dictionary<int, IArticle>();

    QDataResources()
    {
        QDbAccess db = new QDbAccess(Application.dataPath + "/article");
        ReadConsumptions(db);
        ReadEquips(db);
        ReadStuffs(db);
        db.CloseSqlConnection();
    }

    public IArticle GetConsumption(int id)
    {
        return m_Consums[id];
    }

    public IArticle GetEquip(int id)
    {
        return m_Equips[id];
    }

    public IArticle GetStuff(int id)
    {
        return m_Stuffs[id];
    }

    private void ReadArticle(QDbAccess db, ArticleType type, Func<IArticle> createObject, Action<Mono.Data.Sqlite.SqliteDataReader, IArticle> action)
    {
        var read = db.Select(type.ToString(), new string[] { "*" });
        IArticle article;
        while (read.Read())
        {
            article = createObject();
            article.SetID(read.GetInt32(0));
            article.SetName(read.GetString(1));
            article.SetIcon(read.GetString(2));
            article.SetPrice(read.GetInt32(3));
            action(read, article);
        }
    }

    private void ReadConsumptions(QDbAccess db)
    {
        ReadArticle(db, ArticleType.Consumption, () => { return new Consumption(); }, (read, article) =>
        {

            m_Consums.Add(article.ID, article);
        });
    }

    private void ReadEquips(QDbAccess db)
    {
        ReadArticle(db, ArticleType.Equipment, () => { return new Equip(); }, (read, article) =>
        {

            m_Equips.Add(article.ID, article);
        });
    }

    private void ReadStuffs(QDbAccess db)
    {
        ReadArticle(db, ArticleType.Stuff, () => { return new Stuff(); }, (read, article) =>
        {

            m_Stuffs.Add(article.ID, article);
        });
    }
}
