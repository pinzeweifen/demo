using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardButton : MonoBehaviour {

    public KeyboardUI ui;

    private void Start()
    {
        var toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(isOn => {
            ui.gameObject.SetActive(isOn);
        });
        ui.onEnter += () => { toggle.isOn = false; };
    }
}
