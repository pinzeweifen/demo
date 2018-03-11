using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QRPG.BehaviourTree;
using QRPG.Frame;

public partial class QKnapsackUI : QBaseWindow 
{
    private static QKnapsackUI m_Instance;

    public QLatticeUI m_Prefab;
    public ScrollRect m_ScrollRect;

    protected QLatticeUI[] m_Lattices;
    protected EventInfo onClickLattice;


    public static QKnapsackUI Instance { get { return m_Instance; } }

    protected override void Initialise()
    {
        m_Instance = this;
    }
    
    public void InitialiseLatticles(int count)
    {
        m_Lattices = new QLatticeUI[count];
        CreateLattice( ref m_Lattices, 0, count);
    }

    public void AddLattice(int count)
    {
        var tmp = new QLatticeUI[m_Lattices.Length + count];
        for(int i = 0; i < m_Lattices.Length; i++)
        {
            tmp[i] = m_Lattices[i];
        }

        var end = m_Lattices.Length + count;
        CreateLattice(ref tmp, m_Lattices.Length, end);
        m_Lattices = tmp;
    }

    public void SetLatticeArticle(int index,Sprite icon, int count)
    {
        m_Lattices[index].Icon = icon;
        m_Lattices[index].Count = count;
    }

    public void SetLatticeCount(int index, int count)
    {
        m_Lattices[index].Count = count;
    }

    private void CreateLattice(ref QLatticeUI[]list, int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            var go = Instantiate(m_Prefab);
            go.transform.SetParent(m_ScrollRect.content);
            list[i] = go;
            var index = i;
            QEventListener.Get(go.gameObject).onClick += e => {
                if (onClickLattice != null) onClickLattice(new IndexInfo(index));
            };
            
        }
    }
}

/*

public partial class QKnapsackUI
{
    private class SetLatticeAction : BaseActionNode
    {
        protected QKnapsackUI m_KnapsackUI;
        protected QUIResources m_Resources;
        protected QAritcleList m_Knapsack;
        public SetLatticeAction(QKnapsackUI knapsackUI, QUIResources resources, QAritcleList knapsack)
        {
            m_KnapsackUI = knapsackUI;
            m_Resources = resources;
            m_Knapsack = knapsack;
        }

        public override void OnTick(object input)
        {
            var info = (IndexInfo)input;
            var article = m_Knapsack[info.index];
            if(article != null)
            {
                m_KnapsackUI.SetLatticeArticle(info.index, m_Resources.GetSprite(article.Value.Icon), article.Count);
            }
            else
            {
                m_KnapsackUI.SetLatticeCount(info.index,0);
            }
        }
    }

    public INode CreateSetLatticeAction(QUIResources resources,QAritcleList knapsack )
    {
        return new SetLatticeAction(this, resources, knapsack);
    }
}*/