using QRPG.Frame;

public class QDataManager
{
    private static QDataManager m_Instance;
    public static QDataManager Instance { get { return m_Instance ?? (m_Instance = new QDataManager()); } }

    protected QAritcleArray m_KnapsackList;
    public QAritcleArray Knapsack { get { return m_KnapsackList; } set { m_KnapsackList = value; } }

    protected QDataResources m_Resources;
    public QDataResources Resources { get { return m_Resources; } set { m_Resources = value; } }
    
    QDataManager()
    {
        QGameInput.Instance.DataManager = this;
        m_Resources = QDataResources.Instance;
    }
}
