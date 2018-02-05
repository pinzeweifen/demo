using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class MyTweenRootAlpha : MonoBehaviour {


    [Tooltip("初始值")]
    public float from;
    [Tooltip("目标值")]
    public float to;

    public float timer;

    [Tooltip("移动类型")]
    public Ease ease = Ease.Linear;

    public UnityEvent onFinished = new UnityEvent();

    private void OnEnable()
    {
        var group = GetComponent<CanvasGroup>();
        group.alpha = from;
        DOTween.To(() => group.alpha, x => group.alpha = x, to, timer).OnKill(OnFinished);
    }

    private void OnFinished()
    {
        onFinished.Invoke();
    }
}

