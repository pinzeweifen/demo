using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(Mask))]
public class CarouselUI : MonoBehaviour {

    [Tooltip("图片移动速度")]
    [Range(0, 1)]
    public float speed = 0.05f;
    [Tooltip("是否水平显示")]
    public bool isHorizontal=true;
    [Tooltip("是否轮播")]
    public bool isCarousel = true;
    [Tooltip("轮播速度")]
    public float carouselSpeed = 2f;
    [Tooltip("'下一个'按钮")]
    public Button next;
    [Tooltip("'上一个'按钮")]
    public Button previous;
    [Tooltip("图片的父对象")]
    public GridLayoutGroup grid;
    [Tooltip("选中指定索引图片的按钮")]
    public Button[] selectIndex;

    [System.Serializable]
    public class IntEvent : UnityEvent<int> { }
    public IntEvent IndexChanged = new IntEvent();
    public IntEvent IndexClick = new IntEvent();
    
    private Vector2 size;
    private int index = 0;
    private int maxIndex;
    private Image[]images;
    private bool animated = false;
    private RectTransform gridTransform;
    private bool isCarouseling = false;
    private WaitForSeconds wait;

    public void SetIndex(int index)
    {
        if (animated) return;
        StartCoroutine(Animated(gridTransform, size * (index - this.index), speed));
        this.index = index;
    }

    private void Awake()
    {
        next.onClick.AddListener(Next);
        previous.onClick.AddListener(Previous);
        EventListener.Get(gameObject).onExit += e => { StartCoroutine(CarouselImage()); };
        EventListener.Get(gameObject).onEnter += e => { isCarouseling = false; };

        #region 初始化轮播
        if (isCarousel)
        {
            wait = new WaitForSeconds(carouselSpeed);
            StartCoroutine(CarouselImage());
        }
        #endregion

        #region 初始化索引按钮
        if (selectIndex != null)
        {
            for (int i = 0; i < selectIndex.Length; i++)
            {
                var Index = i;
                selectIndex[i].onClick.AddListener(() => { SetIndex(Index); });
            }
        }
        #endregion

        #region 初始化grid
        gridTransform = (RectTransform)grid.transform;
        gridTransform.pivot = new Vector2(0, 1);
        size = ((RectTransform)transform).sizeDelta;
        grid.cellSize = size;
        #endregion

        #region 初始化图片事件
        images = grid.GetComponentsInChildren<Image>();
        maxIndex = images.Length;

        for (int i = 0; i <images.Length;i++)
        {
            var index = i;
            EventListener.Get(images[i].gameObject).onClick += e => {
                if (IndexClick != null) IndexClick.Invoke(index);
            };
        }
        #endregion
        #region 复制最后一个和第一个
        var go = Instantiate(images[images.Length - 1]).transform;
        go.SetParent(gridTransform);
        go.SetAsFirstSibling();
        EventListener.Get(go.gameObject).onClick += e => {
            if (IndexClick != null) IndexClick.Invoke(images.Length - 1);
        };

        go = Instantiate(images[0]).transform;
        go.SetParent(gridTransform);
        EventListener.Get(go.gameObject).onClick += e => {
            if (IndexClick != null) IndexClick.Invoke(0);
        };
        #endregion

        #region 设置图片
        if (isHorizontal)
        {
            gridTransform.sizeDelta = new Vector2(size.x * (images.Length + 2), size.y);
            size = gridTransform.anchoredPosition = new Vector2(-size.x, 0);
        }
        else
        {
            gridTransform.sizeDelta = new Vector2(size.x, size.y * (images.Length + 2));
            size = gridTransform.anchoredPosition = new Vector2(0, size.y);
        }
        #endregion
    }

    private void Next()
    {
        if (animated) return;
        index++;
        StartCoroutine(Animated(gridTransform, size , speed, () =>
        {
            if (index == maxIndex)
            {
                gridTransform.anchoredPosition = size ;
                index = 0;
            }
            if (IndexChanged != null)
                IndexChanged.Invoke(index);
        }));
    }
     
    private void Previous()
    {
        if (animated) return;
        index--;
        StartCoroutine(Animated(gridTransform, size * -1, speed, () =>
        {
            if (index == -1)
            {
                gridTransform.anchoredPosition = size * maxIndex;
                index = maxIndex - 1;
            }
            if (IndexChanged != null)
                IndexChanged.Invoke(index);
        }));
    }
    
    IEnumerator Animated(RectTransform rect,Vector2 offset, float speed, Action endFunction=null)
    {
        animated = true;
        Vector2 point = rect.anchoredPosition + offset;
        do
        {
            rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, point, speed);
            yield return null;
        } while (Vector2.Distance(rect.anchoredPosition, point) > 0.5f);
        rect.anchoredPosition = point;
       
        if (endFunction != null)
            endFunction();

        animated = false;
    }

    IEnumerator CarouselImage()
    {
        isCarouseling = true;
        while (isCarouseling)
        {
            yield return wait;
            if (!isCarouseling) break;
            Next();
        }
    }
}
