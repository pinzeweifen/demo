DbAccess 只是封装了一下数据库命令行，可以作为工具类使用

demo 在 Editor文件夹


new DbLogicalAND(new DbCompareLessThan("id","10"), new DbCompareNotEqual("id","0"));
等价于 id<10 AND id!=0