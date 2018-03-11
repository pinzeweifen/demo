using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class QShopItemUI : MonoBehaviour {

	private Image m_Image;
	private Text m_Text;
    private int m_Index;

    public int Index
    {
        get { return m_Index; }
        set
        {
            m_Index = value;
        }
    }

    public Sprite Icon
    {
        set
        {
            m_Image.sprite = value;
        }
    }

    public string Name
    {
        set
        {
            m_Text.text = value;
        }
    }

}

public partial class QShopItemUI{
    private void Awake()
    {
		m_Image = transform.Find("Image").GetComponent<Image>();
		m_Text = transform.Find("Text").GetComponent<Text>();

  
    }

	private void OnDestroy()
    {

		m_Image = null;
		m_Text = null;

    }
}

public partial class QShopItemUI{

}