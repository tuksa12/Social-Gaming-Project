using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOST, BONUS }
public class BattleManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattlePosition;
    public Transform enemyBattlePosition;
    public Transform screenPosition;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private CharacterStatus playerStatus;
    private CharacterStatus enemyStatus;
    private bool revive, damageBonus;
    private float bonusHeal, nightDamage, season;
    
    
    private GameObject _canvas;

    public BattleState state;
    
    public Text dialogueText;

    public GameObject Victory_Screen, Loss_Screen;

    
#region SetUp    
    void Start()
    {
        state = BattleState.START;
        revive = true;
        damageBonus = false;
        _canvas = GameObject.Find("Canvas");
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattlePosition);
        playerGO.transform.SetParent(_canvas.transform);
        playerStatus = playerGO.GetComponent<CharacterStatus>();
        playerHUD.SetHUD(playerStatus);

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattlePosition);
        enemyGO.transform.SetParent(_canvas.transform);
        enemyStatus = enemyGO.GetComponent<CharacterStatus>();
        if (BattleData.ZombieLevel != 0)
        {
            enemyStatus.level = BattleData.ZombieLevel;
        }
        if (BattleData.NightTime) nightDamage = enemyStatus.damage / 20;
        enemyHUD.SetHUD(enemyStatus);

        string startText = SetSeason();
        dialogueText.text = startText;
        yield return new WaitForSeconds(1.5f);

        dialogueText.text = "Your turn";
        state = BattleState.PLAYERTURN;
    }

    private string SetSeason()
    {
        string startText = "";
        
        switch(BattleData.Season)
        {
            case Season.RAINY:
                startText = "Rain pours from the sky";
                season = -2;
                break;
            case Season.SNOWY:
                startText = "Snow falls steadily";
                season = -4;
                break;
            case Season.SUNNY:
                startText = "The sun lights the path to victory!";
                season = 8;
                break;
            case Season.NONE:
                startText = "Prepare for battle";
                season = 0;
                break;
        }

        return startText;
    }
#endregion

#region Battle
    IEnumerator PlayerAttack()
    {
        int bonus = 0;
        if (damageBonus)
        {
            bonus = (int)playerStatus.damage / 10;
        }
        bool isDead = enemyStatus.TakeDamage(playerStatus.damage + bonus + BattleData.ItemDamage + season);
        
        enemyHUD.SetHP(enemyStatus.currentHealth, enemyStatus.maxHealth);
        if (damageBonus)
        {
            dialogueText.text = "What a blow!";
            damageBonus = false;
        }
        else
        {
            dialogueText.text = "Machete slash!";
        }
        
        yield return new WaitForSeconds(1.5f);

        if (isDead)
        {
            state = BattleState.WIN;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerHeal()
    {
        playerStatus.Heal(15);
        
        playerHUD.SetHP(playerStatus.currentHealth, playerStatus.maxHealth);
        dialogueText.text = "HP healed with bandages!";

        yield return new WaitForSeconds(1.5f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = "Enemy attacks";

        yield return new WaitForSeconds(0.5f);

        if (BattleData.NightTime)
        {
            dialogueText.text = "Fear the dark!";
            yield return new WaitForSeconds(1f);
        }

        bool isDead = playerStatus.TakeDamage(enemyStatus.damage + nightDamage);
        playerHUD.SetHP(playerStatus.currentHealth, playerStatus.maxHealth);
        
        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.BONUS;
            StartCoroutine(TeamBonus());
        }
    }

    IEnumerator TeamBonus()
    {
        int index = UnityEngine.Random.Range(0, 6);
        if (index == 1)
        {
            dialogueText.text = "Team Bonus!";
            yield return new WaitForSeconds(0.5f);
            
            playerStatus.Heal(playerStatus.maxHealth/10);
            playerHUD.SetHP(playerStatus.currentHealth, playerStatus.maxHealth);
            dialogueText.text = "Allies healed!";
        }
        if (index == 0)
        {
            dialogueText.text = "Team Bonus!";
            yield return new WaitForSeconds(0.5f);
            
            dialogueText.text = "Damage bonus!";
            damageBonus = true;
        }

        yield return new WaitForSeconds(1f);
        dialogueText.text = "Your turn";
        state = BattleState.PLAYERTURN;
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
#endregion

#region BattleEnd
    void EndBattle()
    {
        if (state == BattleState.WIN)
        {
            dialogueText.text = "You are victorious!";
            GameObject screen = Instantiate(Victory_Screen, screenPosition);
            screen.transform.SetParent(_canvas.transform);
            Text txt = screen.GetComponentInChildren<Text>();
            txt.text = CalculateBonus();
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "Battle lost";
            GameObject screen = Instantiate(Loss_Screen, screenPosition);
            screen.transform.SetParent(_canvas.transform);
        }
        GameManager.Instance.CurrentPlayer.addXp(BattleData.PlayerXP);
        BattleData.ResetData();
    }

    IEnumerator CoinUpdate(int coin, string userID)
    {
        string uri = "http://localhost/unityserver/GetCoinsBattle.php";
        WWWForm form = new WWWForm();
        form.AddField("coins", coin);
        form.AddField(userID, UserInfo.UserID);
        
        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();
            
            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError ||
                www.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Resource updated successfully");
            }
        }
    }
    
    string CalculateBonus()
    {
        int coin = UnityEngine.Random.Range(enemyStatus.level - 8, enemyStatus.level + 10);
        StartCoroutine(CoinUpdate(coin, UserInfo.UserID));
        return "coin: " + coin;
    }
    
#endregion    
}
