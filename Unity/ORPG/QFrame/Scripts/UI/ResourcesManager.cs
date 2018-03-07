using System.Collections.Generic;
using UnityEngine;
using QFrame;
using Database;
using System;

public class ResourcesManager  
{
    private static ResourcesManager m_Instance;
    public static ResourcesManager Instance { get { return m_Instance ?? (m_Instance = new ResourcesManager()); } }

    protected Dictionary<string, Sprite> m_Sprites = new Dictionary<string, Sprite>();
    protected Dictionary<int, IArticle> m_Equips = new Dictionary<int, IArticle>();
    protected Dictionary<int, IArticle> m_Consums = new Dictionary<int, IArticle>();
    protected Dictionary<int, IArticle> m_Stuffs = new Dictionary<int, IArticle>();

    ResourcesManager()
    {
        DbAccess db = new DbAccess(Application.dataPath + "/article");
        ReadConsumptions(db);
        ReadEquips(db);
        ReadStuffs(db);
        db.CloseSqlConnection();
        Debug.Log(m_Equips.Count);
    }
    
	public Sprite GetSprite(string path)
    {
        if (m_Sprites.ContainsKey(path))
            return m_Sprites[path];

        return (Sprite)Resources.LoadAsync<Sprite>(path).asset;
    }

    private void ReadArticle(DbAccess db, ArticleType type, Func<IArticle> createObject, Action<Mono.Data.Sqlite.SqliteDataReader,IArticle> action)
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

    private void ReadConsumptions(DbAccess db)
    {
        ReadArticle(db,ArticleType.Consumption,()=>{ return new Consumption(); },(read,article)=> {

            m_Consums.Add(article.ID, article);
        });
    }

    private void ReadEquips(DbAccess db)
    {
        ReadArticle(db, ArticleType.Equipment, () => { return new Equip(); }, (read, article) => {

            m_Equips.Add(article.ID,article);
        });
    }

    private void ReadStuffs(DbAccess db)
    {
        ReadArticle(db, ArticleType.Stuff, () => { return new Stuff(); }, (read, article) => {

            m_Stuffs.Add(article.ID, article);
        });
    }
}