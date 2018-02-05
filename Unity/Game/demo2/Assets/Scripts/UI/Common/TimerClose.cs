using UnityEngine;
using UnityEngine.Events;

public class TimerClose : MonoBehaviour {

    public float timer;
    
    public UnityEvent onTimerEnd = new UnityEvent();

    private void Awake()
    {
        Invoke("Event", timer);
    }

    private void Event()
    {
        onTimerEnd.Invoke();
    }
}
