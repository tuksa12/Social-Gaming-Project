using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;

    public void SetHUD(CharacterStatus status)
    {
        nameText.text = status.name;
        //hpSlider.maxValue = status.maxHealth;
        hpSlider.value = status.currentHealth;
        Debug.Log(nameText.text);
    }

    public void SetHP(float current, float max)
    {
        Debug.Log(nameText + " hp set");
        hpSlider.value = current/max;
    }
    
}
