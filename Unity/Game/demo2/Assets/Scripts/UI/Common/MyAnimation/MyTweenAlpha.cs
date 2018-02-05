using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class MyTweenAlpha : MonoBehaviour {

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
        Image image = GetComponent<Image>();

        var color = image.color;
        image.color = new Color(color.r, color.g, color.b, from);

        DOTween.defaultEaseType = ease;

        DOTween.ToAlpha(() => image.color, x => image.color = x, to, timer).OnKill(OnFinished);
    }
   
    private void OnFinished()
    {
        onFinished.Invoke();
    }
}
