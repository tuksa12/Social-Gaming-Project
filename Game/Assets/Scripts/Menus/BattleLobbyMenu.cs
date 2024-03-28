using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleLobbyMenu : MonoBehaviour
{
    [SerializeField] private Button battleButton;
    public string battleScene;

    public void OnBattleButton()
    {
        SceneManager.LoadScene(battleScene);
    }
}
