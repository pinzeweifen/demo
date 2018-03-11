using UnityEngine;


public partial class QUIManager
{
    private static QUIManager m_Instance;
    public static QUIManager Instance { get { return m_Instance ?? (m_Instance = new QUIManager()); } }

    protected QKnapsackUI m_KnapsackUI;
    public QKnapsackUI KnapsackUI { get { return m_KnapsackUI; } set { m_KnapsackUI = value; } }

    protected QUIResources m_Resources;
    public QUIResources Resources { get { return m_Resources; } set { m_Resources = value; } }

    QUIManager()
    {
        QGameInput.Instance.UIManager = this;
        m_Resources = QUIResources.Instance;
    }
}
