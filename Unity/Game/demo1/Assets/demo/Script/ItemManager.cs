using UnityEngine;

public class ItemManager : MonoBehaviour {

    public InfoManager infoManager;
    public IconManager iconManager;
    public Item[] items;

    private void Awake()
    {
        foreach (var item in items)
        {
            item.Count = 0;
            item.InitClickSwap();
            item.EnterEvent += infoManager.Show;
            item.ExitEvent += infoManager.Hide;

            item.SelectEvent += s => {
                iconManager.Show(s);
            };

            item.SwapEvent += (i1, i2) => {
                //逻辑
                iconManager.Hide();
                return true;
            };
        }

        for (int i = 1; i < 3; i++)
        {
            items[i].Article = new Article("Texture/" + i, i * 10);   
        }
    }
}
