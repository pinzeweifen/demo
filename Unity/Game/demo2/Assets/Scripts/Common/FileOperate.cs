using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileOperate {
    
    public static bool IsFileExists(string path)
    {
        return new FileInfo(path).Exists;
    }

    public static bool Write(string path, string data,bool isAppend = false)
    {
        path = Application.dataPath + "/" + path;
        StreamWriter sw;
        FileInfo fi = new FileInfo(path);
        if (!IsFileExists(path))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
        if (!isAppend)
            sw = fi.CreateText();
        else
            sw = fi.AppendText();
        sw.WriteLine(data);
        sw.Close();
        sw.Dispose();
        return false;
    }

    public static ArrayList ReadFileToArray(string path)
    {
        path = Application.dataPath + "/" + path;
        if (!IsFileExists(path))
        {
            return null;
        }

        StreamReader Reader = File.OpenText(path);
        string t_sLine;
        ArrayList t_aArrayList = new ArrayList();
        while ((t_sLine = Reader.ReadLine()) != null)
        {
            t_aArrayList.Add(t_sLine);
        }
        Reader.Close();
        Reader.Dispose();

        return t_aArrayList;
    }

    public static string ReadFileToString(string path)
    {
        path = Application.dataPath + "/" + path;
        if (!IsFileExists(path)) return string.Empty;

        StreamReader Reader = File.OpenText(path);
        string all = Reader.ReadToEnd();
        Reader.Close();
        Reader.Dispose();

        return all;
    }
}
