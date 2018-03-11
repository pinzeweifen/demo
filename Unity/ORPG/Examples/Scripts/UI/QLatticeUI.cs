using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public partial class QLatticeUI : MonoBehaviour {

	private Image m_Icon;
	private Text m_Size;
	private Image m_CountBackground;
	private Text m_Count;

    public int Count
    {
        get
        {
            return int.Parse(m_Count.text);
        }
        set
        {
            if(value <= 1)
            {
                if (value == 0)
                {
                    m_Icon.gameObject.SetActive(false);
                }
                m_Size.gameObject.SetActive(false);
            }
            else
            {
                m_Count.text = m_Size.text = value.ToString();
                
                if (!m_Size.IsActive())
                    m_Size.gameObject.SetActive(true);
            }
        }
    }

    public Sprite Icon
    {
        get { return m_Icon.sprite; }
        set {
            if(value != null)
            {
                if (!m_Icon.IsActive())
                    m_Icon.gameObject.SetActive(true);
            }
            else
            {
                m_Icon.gameObject.SetActive(false);
            }

            m_Icon.sprite = value;
        }
    }
}

public partial class QLatticeUI{
    private void Awake()
    {
		m_Icon = transform.Find("icon").GetComponent<Image>();
		m_Size = transform.Find("size").GetComponent<Text>();
		m_CountBackground = transform.Find("size/countBackground").GetComponent<Image>();
		m_Count = transform.Find("size/count").GetComponent<Text>();

  
    }

	private void OnDestroy()
    {

		m_Icon = null;
		m_Size = null;
		m_CountBackground = null;
		m_Count = null;

    }
}

public partial class QLatticeUI
{

}