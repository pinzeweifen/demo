using UnityEngine;
using UnityEditor;
using System.IO;

public class BuildAnimation : EditorWindow
{
    private float frameRate = 30;
    private float frameTime = 1f;
    private string folder = "Anims";
    private string fileName = "newAnim";

    [MenuItem("Tool/CreateClip %Q")]
    static void ShowEditorWindow()
    {
        GetWindow<BuildAnimation>().Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.TextField("文件夹", folder);
        fileName = EditorGUILayout.TextField("文件名称", fileName);
        frameRate = EditorGUILayout.FloatField("动画帧率", frameRate);
        frameTime = EditorGUILayout.FloatField("帧【0:01】", frameTime);
        if (GUILayout.Button("创建Anim"))
            CreateClip();
    }

    void CreateClip()
    {
        var obj = Selection.GetFiltered<Object>(SelectionMode.TopLevel);
        obj = Sort(obj);

        var time = 1 / frameRate * frameTime;
        ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[obj.Length + 1];
        for (int i = 0; i <= obj.Length; i++)
        {
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(AssetDatabase.GetAssetPath(obj[i == obj.Length ? 0 : i]));
            keyFrames[i] = new ObjectReferenceKeyframe();
            keyFrames[i].time = time * i;
            keyFrames[i].value = sprite;
        }

        AnimationClip clip = new AnimationClip();
        clip.frameRate = frameRate;

        AnimationClipSettings clipSettings = AnimationUtility.GetAnimationClipSettings(clip);
        clipSettings.loopTime = true;
        AnimationUtility.SetAnimationClipSettings(clip, clipSettings);

        EditorCurveBinding curveBinding = new EditorCurveBinding();
        curveBinding.type = typeof(SpriteRenderer);
        curveBinding.propertyName = "m_Sprite";
        AnimationUtility.SetObjectReferenceCurve(clip, curveBinding, keyFrames);

        if (!Directory.Exists("Assets/" + folder))
            Directory.CreateDirectory("Assets/" + folder);

        AssetDatabase.CreateAsset(clip, "Assets/" + folder + "/" + fileName + ".anim");
    }

    Object[] Sort(Object[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            for (int j = i + 1; j < obj.Length; j++)
            {
                if (Strcmp(obj[i].name, obj[j].name) > 0)
                {
                    Swap(ref obj[i], ref obj[j]);
                }
            }
        }
        return obj;
    }

    void Swap(ref Object o1, ref Object o2)
    {
        var tmp = o1;
        o1 = o2;
        o2 = tmp;
    }

    int Strcmp(string a, string b)
    {
        int count = a.Length < b.Length ? a.Length : b.Length;
        for (int i = 0; i < count; i++)
        {
            if (a[i] < b[i])
                return -1;
            else if (a[i] > b[i])
                return 1;
        }
        if (a.Length < b.Length) return -1;
        return 0;
    }
}