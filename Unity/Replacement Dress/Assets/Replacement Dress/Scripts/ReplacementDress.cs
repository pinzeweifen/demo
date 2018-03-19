using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class ReplacementDress : MonoBehaviour
{
    private static System.Exception SmrException = new System.Exception("蒙皮组件不能为空!");

    private List<Material> m_Materials = new List<Material>();
    private List<Transform> m_Bones = new List<Transform>();
    private List<CombineInstance> m_CombineInstances = new List<CombineInstance>();

    private Mesh m_Mesh;
    private Dictionary<string, Transform> m_AllBones = new Dictionary<string, Transform>();
    private SkinnedMeshRenderer m_SkinnedMeshRenderer;

    private int m_Count;
    private Transform[] m_TmpBones;

    private void Awake()
    {
        m_SkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        var childs = GetComponentsInChildren<Transform>();

        m_Count = childs.Length;
        for(int i=0;i< m_Count; i++)
        {
            m_AllBones.Add(childs[i].name, childs[i]);
        }
    }

    /// <summary>
    /// 添加蒙皮
    /// </summary>
    /// <param name="skin"></param>
    public void AddSkin(SkinnedMeshRenderer skin)
    {
        if (skin == null) throw SmrException;

        CombineInstance ci = new CombineInstance();
        ci.mesh = skin.sharedMesh;
        m_CombineInstances.Add(ci);
        m_Materials.AddRange(skin.materials);

        m_TmpBones = skin.bones;
        m_Count = m_TmpBones.Length;
        for(int i = 0; i < m_Count; i++)
        {
            m_Bones.Add(m_AllBones[m_TmpBones[i].name]);
        }
    }

    /// <summary>
    /// 生成蒙皮
    /// </summary>
    public void GeneraterSkin()
    {
        m_Mesh = new Mesh();
        m_Mesh.CombineMeshes(m_CombineInstances.ToArray(), false, false);
        m_SkinnedMeshRenderer.sharedMesh = m_Mesh;
        m_SkinnedMeshRenderer.materials = m_Materials.ToArray();
        m_SkinnedMeshRenderer.bones = m_Bones.ToArray();

        m_Materials.Clear();
        m_Bones.Clear();
        m_CombineInstances.Clear();
    }
    
}
