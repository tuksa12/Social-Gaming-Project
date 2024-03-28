
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCoins : MonoBehaviour
{

    public Button endOfBattleButton;
    // Start is called before the first frame update
    public void Start()
    {
        endOfBattleButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.GetCoinsBattle(UserInfo.UserID, "30"));
        });
    }


}
