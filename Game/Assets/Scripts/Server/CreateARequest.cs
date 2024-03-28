
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateARequest : MonoBehaviour
{
    public InputField createGuildInput;

    public Button Button;
    // Start is called before the first frame update
    public void Start()
    {
        Button.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.RequestingAnItem(UserInfo.UserID, "2", "5"));
        });
    }


}

