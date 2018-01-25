using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class AbstractItem :
    MonoBehaviour, 
    IPointerEnterHandler,
    IPointerExitHandler
{
    
    [Tooltip("物品的图标")]
    public Image icon;
    [Tooltip("限制数量背景的大小")]
    public Text countSize;
    [Tooltip("显示数量")]
    public Text count;

    public Action ExitEvent;
    public Action<string> EnterEvent;
    public Action<Sprite> SelectEvent;
    public Func<AbstractItem, AbstractItem, bool> SwapEvent;

    private object article = null;
    private static AbstractItem selectItem;

    //-----------------------------------------------
    // 重写的函数
    protected abstract void SetIcon();
    protected abstract void SetCount();
    protected virtual string ArticleToString() { return string.Empty; }
    //-----------------------------------------------

    public Sprite Icon
    {
        get { return icon.sprite; }
        set {
            if (value == null)
                HideIcon();
            else
                ShowIcon();
            icon.sprite = value;
        }
    }

    public int Count
    {
        get { return int.Parse(count.text); }
        set
        {
            if (value > 1)
            {
                if(!countSize.gameObject.activeSelf)
                    ShowCount();
                countSize.text = count.text = value.ToString();
            }
            else
            {
                HideCount();
            }
        }
    }

    public object Article
    {
        get { return article; }
        set
        {
            article = value;
            if (value != null)
            {
                SetIcon();
                SetCount();
            }
            else
            {
                Icon = null;
                Count = 0;
            }
        }
    }
    
    public void InitClickSwap()
    {
        EventListener.Get(gameObject).onClick += e => {
            if (selectItem == null)
                SelectItem();
            else
                SoonSwap();
        };
    } 

    public void InitDragSwap()
    {
        EventListener.Get(gameObject).onBeginDrag += e => {
            if (selectItem == null)
                SelectItem();
        };
        EventListener.Get(gameObject).onDrop += e => {
            if (selectItem != null)
                SoonSwap();
        };
    }

    public void Swap(AbstractItem item)
    {
        var tmp = item.Article;
        item.Article = this.Article;
        this.Article = tmp;
    }

    public void Reduce(int count)
    {
        Count -= count;
        if (Count <= 0)
            Article = null;
    }
    
    public void ShowIcon()
    {
        icon.gameObject.SetActive(true);
    }

    public void HideIcon()
    {
        icon.gameObject.SetActive(false);
    }

    public void ShowCount()
    {
        countSize.gameObject.SetActive(true);
    }

    public void HideCount()
    {
        countSize.gameObject.SetActive(false);
    }

    /// <summary>
    /// 选择
    /// </summary>
    private void SelectItem()
    {
        if (article != null)
        {
            selectItem = this;
            if (SelectEvent != null)
                SelectEvent(Icon);
        }
    }

    /// <summary>
    /// 即将交换
    /// </summary>
    private void SoonSwap()
    {
        if (SwapEvent != null && SwapEvent(selectItem, this))
            selectItem.Swap(this);
        selectItem = null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Article != null)
            if (EnterEvent != null)
                EnterEvent(ArticleToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ExitEvent != null)
            ExitEvent();
    }
}
