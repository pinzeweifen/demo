using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class CloseButton : MonoBehaviour {

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
        uiRoot.gameObject.SetActive(false);
        if (activeChanaged != null)
            activeChanaged(uiRoot);
    }
}
