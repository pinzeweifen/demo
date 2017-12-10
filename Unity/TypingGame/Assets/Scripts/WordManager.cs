using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordManager: MonoBehaviour
{
    private static List<string> list = new List<string>();

    public static int Length
    {
        get { return list.Count; }
    }

    public static string GetWord(int index)
    {
        return list[index];
    }

    private void Awake()
    {
        ReadWord("Assets/Resources/Txt/Word.txt");
    }

    private void ReadWord(string path)
    {
        StreamReader reader = File.OpenText(path);
        while (!reader.EndOfStream)
        {
            list.Add(reader.ReadLine());
        }
    }
}
