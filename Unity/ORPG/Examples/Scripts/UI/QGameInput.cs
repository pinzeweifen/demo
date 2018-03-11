using QRPG.Frame;
using UnityEngine;

public partial class QGameInput : MonoBehaviour
{
    private static QGameInput m_Instance;
    public static QGameInput Instance
    {
        get
        {
            if (m_Instance == null)
            {
                var go = new GameObject("QGameInput");
                m_Instance = go.AddComponent<QGameInput>();
            }
            return m_Instance;
        }
    }

    protected QUIManager m_UIManager;
    protected QDataManager m_DataManage;

    public QUIManager UIManager
    {
        set
        {
            m_UIManager = value;
        }
    }

    public QDataManager DataManager
    {
        set
        {
            m_DataManage = value;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_DataManage.Knapsack.Add(new QArticle(m_DataManage.Resources.GetEquip(Random.Range(0, 10)),100));
        }
    }
}

