
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signup : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public InputField confirmPassInput;
    public Button RegisterButton;
    // Start is called before the first frame update
    public void Start()
    {
        RegisterButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.RegisterUser(usernameInput.text, passwordInput.text, confirmPassInput.text));
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
