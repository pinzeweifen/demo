using UnityEngine;
using UnityEditor;
using Database;
using System;
using Mono.Data.Sqlite;

public class EditorTest : EditorWindow
{
    [MenuItem("Tool/Test")]
    static void Init()
    {
        //链接数据库，如果数据库不存在自动创建
        DbAccess db = new DbAccess("article.db");
        
        //创建表，它包含有 TEXT类型 的 name 列  和 INTEGER类型 的 id 列
        db.CreateTable("equip", new string[] { "name", "id" }, new DataType[] { DataType.TEXT, DataType.INTEGER });

        //是否已经创建 equip 表
        Debug.Log(db.IsCreateTable("equip"));

        //向 equip 表插入 name 为 qq , id 为 666 的数据
        db.InsertInto("equip", new string[] { "qq","666" });

        //向 equip 表插入 列 name 为 aa 的数据
        db.InsertIntoSpecific("equip", new string[] { "name" }, new string[] { "aa" });

        //更改 equip 表 id 等于 666 的数据，把 id 改为 999
        db.UpdateInto("equip", new string[] { "id" }, new string[] { "999" }, new DbCompareEqual("id", "666"));

        //删除 equip 表的 name 等于 aa 的行
        db.Delete("equip", new DbCompareEqual("name", "aa"));
        
        //查找 equip 表所有数据
        var data = db.Select("equip", new string[] { "*" });
        while (data.Read())
        {
            try
            {
                Debug.Log(data.GetString(0) + "|" + data.GetInt32(data.GetOrdinal("id")));
            }
            catch (Exception e)
            {
                db.CloseSqlConnection();
                throw new SqliteException(e.ToString());
            }
        }

        //查找 name 列以 q 开头的所有数据
        data = db.SelectWhere("equip", new string[] { "id" }, new DbLogicalLIKE("name", "q%"));
        while (data.Read())
        {
            try
            {
                Debug.Log(data.GetInt32(0));
            }
            catch (Exception e)
            {
                db.CloseSqlConnection();
                throw new SqliteException(e.ToString());
            }
        }

        //清空表
        db.DeleteContents("equip");
        
        //删除表
        db.DropTable("equip");
        
        //关闭数据库链接
        db.CloseSqlConnection();
    }
}