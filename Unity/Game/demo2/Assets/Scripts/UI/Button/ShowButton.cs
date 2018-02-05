using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class ShowButton : MonoBehaviour {

    private Button button;
    public BaseUI uiRoot;
    public static Action<BaseUI> activeChanaged;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Call);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(Call);
        button = null;
    }

    private void Call()
    {
        if (!uiRoot.gameObject.activeSelf)
        {
            uiRoot.gameObject.SetActive(true);
            if (activeChanaged != null)
                activeChanaged(uiRoot);
        }
    }
}
