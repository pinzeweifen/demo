using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRPG.Frame;

public partial class QMain : MonoBehaviour 
{
    public Canvas m_Canvas;
    public QKnapsackUI m_KnapsackUIPrefab;
    public QShowButton m_ShowKnapsack;

    private QUIManager m_UIManager;
    private QDataManager m_DataManager;
    private QTirggerManager m_TirggerManager = new QTirggerManager();

    private void Awake()
    {
        m_UIManager = QUIManager.Instance;
        m_DataManager = QDataManager.Instance;
        InitFrame();
    }

    public void InitFrame()
    {
        m_UIManager.KnapsackUI = (QKnapsackUI)CreateWindow(m_KnapsackUIPrefab, m_ShowKnapsack);
        
        m_UIManager.KnapsackUI.InitialiseLatticles(18);
        m_DataManager.Knapsack = new QAritcleArray(18, 99);

        InitTirgger();
    }

    private void InitTirgger()
    {
        var action = m_UIManager.KnapsackUI.CreateSetLatticeAction(m_UIManager.Resources, m_DataManager.Knapsack);
        m_TirggerManager.Add( m_DataManager.Knapsack.CreateUpdateEventTirgger(action) );

        action = m_DataManager.Knapsack.CreateListRemoveArticleAction(1);
        m_TirggerManager.Add(m_UIManager.KnapsackUI.CreateClickEventTirgger(action));
        
    }

    private QBaseWindow CreateWindow(QBaseWindow prefab, QShowButton button)
    {
        var go = Instantiate(prefab);
        go.transform.SetParent(m_Canvas.transform);
        button.Window = go;
        return go;
    }
}

