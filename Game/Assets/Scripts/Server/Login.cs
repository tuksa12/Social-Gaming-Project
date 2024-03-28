using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;
    // Start is called before the first frame update
    public void Start()
    {
        loginButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.Login(usernameInput.text, passwordInput.text));
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
