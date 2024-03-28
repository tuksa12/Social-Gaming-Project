
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateGuild : MonoBehaviour
{
    public InputField createGuildInput;
   
    public Button RegisterButton;
    // Start is called before the first frame update
    public void Start()
    {
        RegisterButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.createGuild(createGuildInput.text));
        });
    }


}
