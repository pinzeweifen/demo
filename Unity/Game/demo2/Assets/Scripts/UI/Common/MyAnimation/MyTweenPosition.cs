using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class MyTweenPosition : MonoBehaviour {

    [Tooltip("初始值")]
    public Vector3 from;
    [Tooltip("目标值")]
    public Vector3 to;

    public float timer;

    [Tooltip("移动类型")]
    public Ease ease = Ease.Linear;

    public UnityEvent onFinished = new UnityEvent();

    private void OnEnable()
    {
        Image image = GetComponent<Image>();

        image.rectTransform.position = from;

        DOTween.defaultEaseType = ease;

        image.rectTransform.DOMove(to, timer).OnKill(OnKill);
    }

    private void OnKill()
    {
        onFinished.Invoke();
    }
}
