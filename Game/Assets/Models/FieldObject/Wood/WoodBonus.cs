using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBonus : MonoBehaviour
{
    [SerializeField] private int bonus = 5;
    [SerializeField] private int xp = 2;
    private void OnMouseDown() {
        GameManager.Instance.CurrentPlayer.addWood(bonus);
        GameManager.Instance.CurrentPlayer.addXp(xp);
        Destroy(gameObject);
    }
}
