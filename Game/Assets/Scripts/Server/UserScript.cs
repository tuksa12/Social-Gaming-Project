using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserScript: MonoBehaviour
{
  
    public Button button;
    // Start is called before the first frame update
    public void Start()
    {
        button.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.GetUserInfo(UserInfo.UserID));
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}