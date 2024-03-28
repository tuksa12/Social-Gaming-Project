using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text xpText;
    [SerializeField] private Text health;

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject inventory;

    private void Awake() {
        Assert.IsNotNull(menu);
        Assert.IsNotNull(inventory);
    }

    public void toggleMenu() {
        menu.SetActive(!menu.activeSelf);
    }

    public void toggleInventory() {
        inventory.SetActive(!inventory.activeSelf);
    }
}

