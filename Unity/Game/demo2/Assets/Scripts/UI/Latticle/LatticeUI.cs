using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LatticeUI : MonoBehaviour {

    public Image icon;
    public Text count;
    public Text backgroundSize;

    private IArticle value;

    public IArticle Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            Count = value.Count;
        }
    }

    int Count
    {
        get { return int.Parse(count.text); }
        set
        {
            if(value <= 0)
            {
                icon.gameObject.SetActive(false);
                backgroundSize.gameObject.SetActive(false);
                this.value = null;
            }
            else
            {
                icon.gameObject.SetActive(true);
                icon.sprite = this.value.Icon;
                if (value > 1)
                {
                    backgroundSize.gameObject.SetActive(true);
                    count.text = backgroundSize.text = value.ToString();
                }
                else
                {
                    backgroundSize.gameObject.SetActive(false);
                }
            }
        }
    }

    public void Apply()
    {
        Count--;
    }

    public void Apply(int count)
    {
        Count -= count;
    }

    public void Add(int count)
    {
        Count += count;
    }
}
