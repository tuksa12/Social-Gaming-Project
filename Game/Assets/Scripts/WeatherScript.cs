using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherScript : MonoBehaviour
{
    public enum Seasons
    {
        None,
        Spring,
        Summer,
        Autumn,
        Winter
    };

    public enum Weather
    {
        None,
        Sunny,
        HotSun,
        Rain,
        Snow
    };

    public Seasons currentSeason;

    public Weather currentWeather;

    [Header("Time Settings")] 
    public float seasonTime;
    public float springTime;
    public float summerTime;
    public float autumnTime;
    public float winterTime;

    public int currentYear;

    private void Start()
    {
        this.currentSeason = Seasons.Spring;
        this.currentWeather = Weather.Sunny;
        this.currentYear = 1;

        this.seasonTime = this.springTime;
    }

    public void ChangeSeason(Seasons seasonType)
    {
        
    }

    public void ChangeWeather(Weather weatherType)
    {
        
    }
}
