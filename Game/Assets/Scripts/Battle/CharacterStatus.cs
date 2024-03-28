using System;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public string name;
    public int level;
    public GameObject gameObj;
    public float maxHealth;
    public float currentHealth;
    public float damage;

    public bool TakeDamage(float damage)
    {
        currentHealth -= damage;

        Debug.Log(currentHealth + " is the current health");
        if (currentHealth <= 0)
            return true;

        return false;
    }

    public void Heal(float heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}
