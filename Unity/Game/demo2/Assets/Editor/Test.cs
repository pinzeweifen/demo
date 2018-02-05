using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Test : EditorWindow {

    [MenuItem("Tool/Test")]
    private static void Init()
    {
        FileOperate.Write("123/1.txt", "qq719549260");
    }
}
