using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuildMenu : MonoBehaviour
{
    [SerializeField]
    private InputField guildName;
    [SerializeField]
    private Button joinGuild;
    [SerializeField]
    private Button createGuild;
    // Start is called before the first frame update
    public void Start()
    {
        joinGuild.onClick.AddListener(() =>
        {
            //StartCoroutine(Main.Instance.Web.RegisterUser(usernameInput.text, passwordInput.text, confirmPassInput.text)); -> When clicking the button -> try to enter an existing guild that exists on the server
        });
    }

    public void LoadCreation()
    {
        SceneManager.LoadScene("guildcreation");
    }

}
