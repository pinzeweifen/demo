using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour {

    public Text size;
    public Text content;

    private Vector3 pos;

    public void Show(string info)
    {
        size.text = content.text = info;
        pos = Input.mousePosition;
        transform.position = new Vector3(pos.x + 5, pos.y - 5, 0);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        pos = Input.mousePosition;
        transform.position = new Vector3(pos.x+5,pos.y-5,0);
    }
}
