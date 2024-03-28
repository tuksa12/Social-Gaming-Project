using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieCollision : MonoBehaviour
{

    public int level, damage;
    private void OnTriggerEnter(Collider collision)
     {
          Debug.Log("collision");
          if (collision.gameObject.name == "Player")
          {
              //sending data to BattleData
              DateTime now = DateTime.Now;
              if (now.Hour > 8 || now.Hour < 6)
              {
                  BattleData.NightTime = true;
              }
              else
              {
                  BattleData.NightTime = false;
              }

              SceneManager.LoadScene("BattleLobby");
              Destroy(gameObject);
          }
     }
}
