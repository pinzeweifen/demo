using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class MyTweenColor : MonoBehaviour {

    [Tooltip("初始值")]
    public Color from;
    [Tooltip("目标值")]
    public Color to;

    public float timer;

    [Tooltip("移动类型")]
    public Ease ease = Ease.Linear;

    public UnityEvent onFinished = new UnityEvent();

    private void OnEnable()
    {
        Image image = GetComponent<Image>();

        var color = image.color;
        image.color = from;

        DOTween.defaultEaseType = ease;

        DOTween.To(() => image.color, x => image.color = x, to, timer).OnKill(OnFinished);
    }
    
    private void OnFinished()
    {
        onFinished.Invoke();
    }
}
