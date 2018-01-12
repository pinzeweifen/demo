using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(ToggleGroup))]
public class PageTurningUI : MonoBehaviour {

    public Toggle[] toggles;
    public GameObject[] pages;
    public Button[] deletePages;

    [System.Serializable]
    public class ClickToggle : UnityEvent<int> { }
    public ClickToggle clickToggle = new ClickToggle();

    private void Awake()
    {
        int count = toggles.Length;
        for(int i = 0; i < count; i++)
        {
            var index = i;
            toggles[i].onValueChanged.AddListener(isOn=> {
                pages[index].gameObject.SetActive(isOn);
                if (isOn)
                    clickToggle.Invoke(index);
            });
            deletePages[i].onClick.AddListener(()=> {
                Destroy(toggles[index]);
                Destroy(pages[index]);
            });
        }
        count = pages.Length;
        for(int i = 1;i< count; i++)
        {
            pages[i].SetActive(false);
        }
    }
}
