using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MessageBoxUI : MonoBehaviour {

    public enum StandardButton
    {
        OK,No,Cancel
    }

    public Text title;
    public Text text;
    public Button ok;
    public Button no;
    public Button cancel;


    public string Content
    {
        get { return text.text; }
        set { text.text = value; }
    }

    [System.Serializable]
    public class ClickButton : UnityEvent<StandardButton> { }
    public ClickButton clickButton = new ClickButton();

    private void Awake()
    {
        if(ok!=null)
            ok.onClick.AddListener(() => { clickButton.Invoke(StandardButton.OK); });

        if (no != null)
            no.onClick.AddListener(() => { clickButton.Invoke(StandardButton.No); });

        if (cancel != null)
            cancel.onClick.AddListener(() => { clickButton.Invoke(StandardButton.Cancel); });
    }
}
