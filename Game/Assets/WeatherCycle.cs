using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherCycle : MonoBehaviour
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

    public ParticleSystem rain;
    public ParticleSystem snow;
    
    [Header("Light Settings")] 
    public Light sunLight;
    
    private float defaultLightIntensity;
    public float summerLightIntensity;
    public float autumnLightIntensity;
    public float winterLightIntensity;
   // public float springLightIntensity;

   private Color defaultLightColor;
   public Color summerColor;
   public Color autumnColor;
   public Color winterColor;
    
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

        this.defaultLightColor = this.sunLight.color;
        this.defaultLightIntensity = this.sunLight.intensity;
        this.rain.Stop();
        this.snow.Stop();
    }

    public void ChangeSeason(Seasons seasonType)
    {
        if (seasonType != this.currentSeason)
        {
            switch (seasonType)
            {
                case Seasons.Spring:
                    currentSeason = Seasons.Spring;
                    break;
                case Seasons.Autumn:
                    currentSeason = Seasons.Autumn;
                    break;
                case Seasons.Summer:
                    currentSeason = Seasons.Summer;
                    break;
                case Seasons.Winter:
                    currentSeason = Seasons.Winter;
                    break;
            }
        }
    }

    public void ChangeWeather(Weather weatherType)
    {
        if(weatherType != this.currentWeather)
            switch (weatherType)
            {
                case Weather.Snow:
                    currentWeather = Weather.Snow;
                    BattleData.Season = Season.SNOWY;
                    this.rain.Stop();
                    this.snow.Play();
                    break;
                case Weather.Rain:
                    currentWeather = Weather.Rain;
                    BattleData.Season = Season.RAINY;
                    this.rain.Play();
                    break;
                case Weather.Sunny:
                    currentWeather = Weather.Sunny;
                    BattleData.Season = Season.SUNNY;
                    this.snow.Stop();
                    break;
                case Weather.HotSun:
                    currentWeather = Weather.HotSun;
                    BattleData.Season = Season.SUNNY;
                    break;
            }
    }


    private void Update()
    {
        this.seasonTime -= Time.deltaTime;

        if (this.currentSeason == Seasons.Spring)
        {
            ChangeWeather(Weather.Sunny);
           // LerpSunIntensity(this.sunLight, defaultLightIntensity); 
           // LerpLightColor(this.sunLight, defaultLightColor);
            
            if (this.seasonTime <= 0f)
            {
                ChangeSeason(Seasons.Summer);
                this.seasonTime = this.summerTime;
            }
        }

        if (this.currentSeason == Seasons.Summer)
        {
            ChangeWeather(Weather.HotSun);
          //  LerpSunIntensity(this.sunLight, summerLightIntensity); 
           // LerpLightColor(this.sunLight, summerColor);

            if (this.seasonTime <= 0f)
            {
                ChangeSeason(Seasons.Autumn);
                this.seasonTime = this.autumnTime;
            }
        }
        
        if (this.currentSeason == Seasons.Autumn)
        {
            ChangeWeather(Weather.Rain);
          //  LerpSunIntensity(this.sunLight, autumnLightIntensity); 
           // LerpLightColor(this.sunLight, autumnColor);
            
            if (this.seasonTime <= 0f)
            {
                ChangeSeason(Seasons.Winter);
                this.seasonTime = this.winterTime;
            }
        }
        
        if (this.currentSeason == Seasons.Winter)
        {
            ChangeWeather(Weather.Snow);
           // LerpSunIntensity(this.sunLight,winterLightIntensity); 
          //  LerpLightColor(this.sunLight, winterColor);

            if (this.seasonTime <= 0f)
            {
                this.currentYear++;
                ChangeSeason(Seasons.Spring);
                this.seasonTime = this.springTime;
            }
        }
    }

    private void LerpLightColor(Light light, Color c)
    {
        light.color = Color.Lerp(light.color, c, 0.2f * Time.deltaTime);
    }

    private void LerpSunIntensity(Light light, float intensity)
    {
        light.intensity = Mathf.Lerp(light.intensity, intensity, 0.2f * Time.deltaTime);
    }
}


