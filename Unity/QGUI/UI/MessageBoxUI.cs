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
    
    [System.Serializable]
    public class ClickButton : UnityEvent<StandardButton> { }
    public ClickButton clickButton = new ClickButton();

    private static MessageBoxUI instance;
    public static MessageBoxUI Instance { get { return instance; } }

    public string Title
    {
        get { return title.text; }
        set { title.text = value; }
    }

    public string Content
    {
        get { return text.text; }
        set { text.text = value; }
    }

    private void Awake()
    {
        instance = this;
        if (ok!=null)
            ok.onClick.AddListener(() => {
                clickButton.Invoke(StandardButton.OK);
                HideButton();
                Hide();
            });

        if (no != null)
            no.onClick.AddListener(() => {
                clickButton.Invoke(StandardButton.No);
                HideButton();
                Hide();
            });

        if (cancel != null)
            cancel.onClick.AddListener(() => {
                clickButton.Invoke(StandardButton.Cancel);
                HideButton();
                Hide();
            });

        HideButton();
        Hide();
    }

    public static void about(string title, string text)
    {
        Instance.Title = title;
        Instance.Content = text;
        Instance.Show();
    }

    public static void warning(string title, string text)
    {
        Instance.Title = title;
        Instance.Content = text;
        Instance.ShowOk();
        Instance.ShowNo();
        Instance.ShowCancel();
        Instance.Show();
    }

    public static void question(string title, string text)
    {
        Instance.Title = title;
        Instance.Content = text;
        Instance.ShowOk();
        Instance.ShowNo();
        Instance.Show();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void HideButton()
    {
        ok.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        cancel.gameObject.SetActive(false);
    }

    public void ShowOk()
    {
        ok.gameObject.SetActive(true);
    }

    public void ShowNo()
    {
        no.gameObject.SetActive(true);
    }

    public void ShowCancel()
    {
        cancel.gameObject.SetActive(true);
    }
}
