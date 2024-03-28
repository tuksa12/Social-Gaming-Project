using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button quit;
    public void LoadLogin()
    {
        SceneManager.LoadScene("UserInfo");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
