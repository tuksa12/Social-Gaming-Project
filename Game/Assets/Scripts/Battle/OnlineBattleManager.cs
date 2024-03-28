using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/*
 * Problem1: know when all allies have attacked or when all allies have taken damage
 * Idea: create a new IEnumerator that tells the server the player has done his action and
 *      another IEnumerator that tells the player wether all players have finished their actions
 *
 * Problem2: know when all allies have taken damage
 * Idea: create a new IEnumerator that tells the server the player has taken damage and another
 *      IEnumerator that tells the player wether all players are done taking damage
 *
 * OBS: Discontinued due to lack of time.
 */
public enum BattleStateM { START, HOST, CONNECTING, ERROR, PLAYERTURN, ENEMYTURN, WIN, LOST }
public class OnlineBattleManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattlePosition;
    public Transform enemyBattlePosition;

    private GameObject _canvas;

    public BattleStateM state;
    
    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private CharacterStatus playerStatus;
    private CharacterStatus enemyStatus;
    
    

    private void Start()
    {
        state = BattleStateM.START;
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
        enemyHUD.SetHUD(enemyStatus);

        dialogueText.text = "Prepare for battle!";
        yield return new WaitForSeconds(1.5f);

        dialogueText.text = "Your turn";
        state = BattleStateM.PLAYERTURN;
        
    }

    IEnumerator TakeDamage()
    {
        string uri = "";
        using (UnityWebRequest www = UnityWebRequest.Get(uri))
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
                float damageTaken = float.Parse(www.result.ToString());
                
                bool isDead = playerStatus.TakeDamage(damageTaken);
                playerHUD.SetHP(playerStatus.currentHealth, playerStatus.maxHealth);

                if (isDead)
                {
                    state = BattleStateM.LOST;
                }
                else
                {
                    dialogueText.text = "Your turn";
                }
            }
        }
    }

    IEnumerator DealDamage()
    {
        string uri = "";
        WWWForm form = new WWWForm();
        form.AddField("damage", (int)playerStatus.damage);

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
                dialogueText.text = "Attack successful!";
            }
        }
    }

    //call when all players have attacked to update the enemies HUD
    IEnumerator GetEnemyHealth()
    {
        string uri = "";
        using (UnityWebRequest www = UnityWebRequest.Get(uri))
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
                float currentHealth = float.Parse(www.result.ToString());
                
                bool isDead = enemyStatus.TakeDamage(enemyStatus.currentHealth - currentHealth);
                enemyHUD.SetHP(playerStatus.currentHealth, playerStatus.maxHealth);

                if (isDead)
                {
                    state = BattleStateM.WIN;
                }
                else
                {
                    dialogueText.text = "Your turn";
                }
            }
        }
    }
    
    IEnumerator Heal()
    {
        playerStatus.Heal(10);
        
        playerHUD.SetHP(playerStatus.currentHealth, playerStatus.maxHealth);
        dialogueText.text = "HP healed!";

        yield return new WaitForSeconds(1.5f);

        state = BattleStateM.ENEMYTURN;
    }

    public void OnTakeDamage()
    {
        StartCoroutine(TakeDamage());
    }

    public void OnDealDamage()
    {
        StartCoroutine(DealDamage());
    }

    public void OnHeal()
    {
        StartCoroutine(Heal());
    }
}
