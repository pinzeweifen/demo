using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public float speed = 30;
    public float addSpeed = 20;
    public int wordCount = 100;
    public int surplus;


    public static List<Item>[] list = new List<Item>[26];
    public Action LoseEvent;

    private Transform canvas;

    public void StartLevel(int level)
    {
        surplus = wordCount;
        StartCoroutine(CreateItem(level));
    }

    public bool IsEmpty()
    {
        for(int i = 0; i < 26; i++)
        {
            if (list[i].Count != 0)
                return false;
        }
        return true;
    }

    private void Awake()
    {
        canvas = GameObject.Find("Canvas").transform;

        for(int i = 0; i < 26; i++)
        {
            list[i] = new List<Item>();
        }
    }

    private GameObject go;
    IEnumerator CreateItem(int level)
    {
        var endCount = wordCount - 1;
        for (int j = 0; j < wordCount; j++)
        {
            surplus--;
            go = Instantiate(itemPrefab);
            go.transform.SetParent(canvas);
            var item = go.GetComponent<Item>();
            var index = item.Init(speed + addSpeed * level, list);
            item.DestroyEvent += () => {
                list[index].RemoveAt(item.Index);
                LoseEvent();
            };
            if (j == endCount) break;
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, -level + 10.0f));
        }
    }
}
