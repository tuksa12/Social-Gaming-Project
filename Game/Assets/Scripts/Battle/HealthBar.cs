using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image filler;

    public void UpdateCurrentHealth(float change)
    {
        if (change >= 0) Heal(change);
        else
        {
            Damage(change);
        }
    }

    private void Heal(float change)
    {
        filler.fillAmount += change / 100;
    }

    private void Damage(float change)
    {
        filler.fillAmount -= change / 100;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("click");
            UpdateCurrentHealth(-30);
        }
    }
}
