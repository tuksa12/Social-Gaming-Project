using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoginMenu : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button enterButton;


    public int nameLengthMin = 4;
    public int passwordLengthMin = 8;
    public string loginUrl = "login/";

    public void CallLogin()
    {
        //StartCoroutine(Login());
    }

    //IEnumerator Login()
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("username", usernameInput.text);
    //    form.AddField("password", passwordInput.text);
    //    using WWW www = new WWW(Client.BASE_URL + loginUrl, form);
    //    yield return www;
    //    string wwwText = www.text.TrimStart();
    //    Debug.Log(wwwText);
    //    if (wwwText.StartsWith("0") || wwwText.StartsWith("1"))
    //    {
    //        SceneManager.LoadScene("MainMenu");
    //    }
    //}

    public void VerifyInputs()
    {
        bool nameVerified = usernameInput.text.Length >= nameLengthMin;
        bool passwordVerified = passwordInput.text.Length >= passwordLengthMin;
        enterButton.interactable = nameVerified && passwordVerified && usernameInput.text != passwordInput.text;
    }


}
