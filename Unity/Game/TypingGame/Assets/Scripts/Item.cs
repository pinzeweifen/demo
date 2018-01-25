using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Image))]
public class Item : MonoBehaviour {

    public Text text;
    public float speed=0;

    private string word;
    private float end;
    private int index;
    public Action DestroyEvent;

    public string Word
    {
        get { return word; }
        set
        {
            word = value;
            text.text = value;
        }
    }

    public int Index
    {
        get { return index; }
    }

    public int Init(float speed, List<Item>[]list)
    {
        Word = WordManager.GetWord(UnityEngine.Random.Range(0, WordManager.Length));
        myTr = transform;
        var size = GetComponent<Image>().rectTransform.sizeDelta * 0.5f;
        myTr.position = new Vector3(UnityEngine.Random.Range(size.x, Screen.width - size.x), 600 + size.y, 0);
        end = -size.y;
        var index = (int)word[0] - 'a';
        list[index].Add(this);
        this.speed = speed;
        this.index = list[index].Count - 1;
        return index;
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
    
    private Transform myTr;
    private void Update()
    {
        myTr.Translate(Vector3.down * Time.deltaTime * speed);
        if(myTr.transform.position.y < end)
        {
            if (DestroyEvent != null)
                DestroyEvent();
            Destroy(gameObject);
        }
    }
}
