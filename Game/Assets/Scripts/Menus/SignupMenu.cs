using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignupMenu : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField passwordInput;
    public Button signupButton;

    public int nameLengthMin = 4;
    public int passwordLengthMin = 8;
    public string signupUrl = "signup/";

    public void CallSignup()
    {
        //StartCoroutine(Signup());
    }

    //IEnumerator Signup()
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("username", nameInput.text);
    //    form.AddField("password1", passwordInput.text);
    //    form.AddField("password2", passwordInput.text);
    //    using (WWW www = new WWW(Client.BASE_URL + signupUrl, form))
    //    {
    //        yield return www;
    //        string wwwText = www.text.TrimStart();
    //        Debug.Log(wwwText);
    //        if (wwwText.StartsWith("0"))
    //        {
    //            SceneManager.LoadScene("MainMenu");
    //        }
    //    }
    //}

    public void VerifyInputs()
    {
        bool nameVerified = nameInput.text.Length >= nameLengthMin;
        bool passwordVerified = passwordInput.text.Length >= passwordLengthMin;
        signupButton.interactable = nameVerified && passwordVerified && nameInput.text != passwordInput.text;
    }
}
