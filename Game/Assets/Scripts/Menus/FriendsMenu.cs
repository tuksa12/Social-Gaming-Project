using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendsMenu : MonoBehaviour
{   
    [SerializeField]
    private InputField friendName;
    [SerializeField]
    private Button addFriend;
    [SerializeField]
    private Text friendsList;
    // Start is called before the first frame update
    public void Start()
    {
        addFriend.onClick.AddListener(() =>
        {
            //StartCoroutine(Main.Instance.Web.RegisterUser(usernameInput.text, passwordInput.text, confirmPassInput.text)); -> When clicking the button -> try to add a friend that exists on the server
        });
    }

}
