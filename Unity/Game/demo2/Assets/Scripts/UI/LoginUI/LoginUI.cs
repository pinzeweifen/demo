using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LoginUI : MonoBehaviour {

    public InputField user;
    public InputField password;
    public Button loginButton;
    public Toggle memory;
    public Toggle confirm;
    public string userFile;

    public UnityEvent onLoginOk = new UnityEvent();
    public UnityEvent onLoginLose = new UnityEvent();
    
    private void Awake()
    {
        loginButton.onClick.AddListener(OnLogin);
        confirm.onValueChanged.AddListener(ButtonEnabled);
        password.onEndEdit.AddListener(x=> { Debug.Log(555); });

        if (FileOperate.IsFileExists(userFile))
            user.text = FileOperate.ReadFileToString(userFile);
    }

    private void OnDestroy()
    {
        loginButton.onClick.RemoveListener(OnLogin);
        confirm.onValueChanged.RemoveListener(ButtonEnabled);
    }

    private void ButtonEnabled(bool isOn)
    {
        loginButton.interactable = isOn;
    }

    private void OnLogin()
    {
        if (user.text == string.Empty || password.text == string.Empty)
            return;

        //! TODO
        
        if (true)
        {
            if (memory.isOn)
            {
                Debug.Log(213);
                FileOperate.Write(userFile,user.text);
            }
            onLoginOk.Invoke();
        }
        else
        {
            onLoginLose.Invoke();
        }
    }
}
