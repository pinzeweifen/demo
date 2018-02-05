using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyboardUI : MonoBehaviour {

    public Transform parent;
    public Transform box;
    public GameObject prefab;
    public InputField inputField;

    private bool[] arrays;
    private Vector2 size;
    private Transform [] keys;
    private Text[] texts = new Text[39];
    private bool isLower = true;
    private bool isMove = true;
    private Vector2 maxPos;

    private static KeyboardUI instance;
    public static KeyboardUI Instance { get{ return instance; } }
    public Action onEnter; 

    private void Awake()
    {
        instance = this;
        EventListener.Get(gameObject).onClick += e => {
            gameObject.SetActive(false);
            if (onEnter != null) onEnter();
        };
        
        EventListener.Get(box.gameObject).onEnter += e => {
            isMove = false;
        };

        EventListener.Get(box.gameObject).onExit += e => {
            isMove = true;
        };

        arrays = new bool[50];
        keys = new Transform[39];
        
        Button []buttons = new Button[39];
        for(int i = 0; i < keys.Length; i++)
        {
            buttons[i] = Instantiate(prefab).GetComponent<Button>();
            texts[i] = buttons[i].GetComponentInChildren<Text>();
            keys[i] = buttons[i].transform;
            buttons[i].transform.SetParent(parent);
        }
        
        for(int i = 0; i < 26; i++)
        {
            var ch = (char)(i + 'a');
            texts[i].text = ch.ToString();
            buttons[i].onClick.AddListener(()=> { AddToInputField(ch); });
        }

        for (int i = 26; i < 36; i++)
        {
            var ch = (char)(i + '0');
            texts[i].text = ch.ToString();
            buttons[i].onClick.AddListener(() => { AddToInputField(ch); });
        }

        texts[36].text = "shift";
        buttons[36].onClick.AddListener(()=> {
            isLower = !isLower;
            ChangedText(isLower?'a':'A');
        });

        texts[37].text = "space";
        buttons[37].onClick.AddListener(() => { AddToInputField(' '); });

        texts[38].text = "Enter";
        buttons[38].onClick.AddListener(() => {
            gameObject.SetActive(false);
            if(onEnter!=null) onEnter();
        });

        size = ((RectTransform)buttons[0].transform).sizeDelta;
        maxPos = new Vector2(Screen.width - size.x * 11, Screen.height - size.y * 6);
        var boxTr = ((RectTransform)box.transform);
        boxTr.localPosition = new Vector3(-10,-10,0);
        boxTr.sizeDelta = new Vector2(size.x * 10 + 20, size.y * 5 + 20);
        parent.transform.localPosition = new Vector3(10,10,0);
    }
    
    private Vector3 moveTo;
    private float timer=0.1f;
    private void Update()
    {
        if (isMove)
        {
            box.position = Vector3.Lerp(box.position, moveTo, 0.05f);
            if (Vector2.Distance(box.position, moveTo) < 3)
            {
                RandValue();
            }
        }
    }

    private void RandValue()
    {
        moveTo = new Vector3(UnityEngine.Random.Range(size.x, maxPos.x), UnityEngine.Random.Range(size.y, maxPos.y), 0);
    }

    private void ChangedText(char value)
    {
        for (int i = 0; i < 26; i++)
        {
            texts[i].text = ((char)(i + value)).ToString();
        }
    }

    private void AddToInputField(char ch)
    {
        inputField.text += ch;
    }

    private void OnEnable()
    {
        int tmp;
        for (int i = 0; i < keys.Length; i++)
        {
            do
            {
                tmp = UnityEngine.Random.Range(0, 50);
            } while (arrays[tmp] != false);

            arrays[tmp] = true;
            keys[i].localPosition = new Vector3(tmp % 10 * size.x, tmp / 10 * size.y, 0);
        }
        isMove = true;
        RandValue();
    }

    private void OnDisable()
    {
        for(int i = 0; i < arrays.Length; i++)
        {
            arrays[i] = false;
        }
    }
}
