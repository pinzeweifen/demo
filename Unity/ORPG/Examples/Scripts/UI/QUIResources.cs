using System.Collections.Generic;
using UnityEngine;

public class QUIResources  
{
    private static QUIResources m_Instance;
    public static QUIResources Instance { get { return m_Instance ?? (m_Instance = new QUIResources()); } }

    protected Dictionary<string, Sprite> m_Sprites = new Dictionary<string, Sprite>();


    QUIResources()
    {

    }
    
	public Sprite GetSprite(string path)
    {
        if (m_Sprites.ContainsKey(path))
            return m_Sprites[path];

        return (Sprite)Resources.LoadAsync<Sprite>(path).asset;
    }

    
}