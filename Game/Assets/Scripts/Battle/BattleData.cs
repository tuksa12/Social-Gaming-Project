using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Season {SUNNY, RAINY, SNOWY, NONE}
public static class BattleData
{
    public static Season Season = Season.NONE;
    public static float ItemDamage = 0;
    public static bool NightTime = false;
    public static int ZombieLevel = 0;
    public static int PlayerXP = 10;

    public static void ResetData()
    {
        ItemDamage = ZombieLevel = 0;
        NightTime = false;
        Season = Season.NONE;
    }
}