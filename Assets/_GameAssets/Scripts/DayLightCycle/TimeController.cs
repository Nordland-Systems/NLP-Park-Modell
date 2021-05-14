using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TimeController : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private Light moon;
    [SerializeField] private float secondsInFullDay = 120f;

    [Range(0f, 1f)] [SerializeField] private float currentTimeOfDay = 0;
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;
    private float moonInitialIntensity;

    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI clock;

    private void Start()
    {
        sunInitialIntensity = sun.intensity;
        moonInitialIntensity = moon.intensity;
    }

    private void Update()
    {
        UpdateSun();
        UpdateMoon();
        UpdateClock();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }

    private void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;

        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if(currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
    
    private void UpdateMoon()
    {
        moon.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f), 170, 0);

        float intensityMultiplier = 1;

        if (currentTimeOfDay >= 0.25f && currentTimeOfDay <= 0.73f)
        {
            intensityMultiplier = 0;
        }
        else if(currentTimeOfDay >= 0.23f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.25f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay <= 0.75f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.75f) * (1 / 0.02f)));
        }

        moon.intensity = moonInitialIntensity * intensityMultiplier;
    }

    private void UpdateClock()
    {
        string clockText = "00:00";
        int totalMinutes = (int)(currentTimeOfDay * 1440);
        /*int hours = (totalMinutes - totalMinutes % 60) / 60;
        int minutes = totalMinutes - hours * 60;

        if (hours < 10 && minutes < 10)
        {
            clockText = "0" + hours + ":0" + minutes;
        }
        else if (hours > 10 && minutes < 10)
        {
            clockText = "" + hours + ":0" + minutes;
        }
        else if (hours < 10 && minutes > 10)
        {
            clockText = "0" + hours + ":" + minutes;
        }

        */
        
        TimeSpan span = TimeSpan.FromMinutes(totalMinutes);
        string label = span.ToString(@"hh\:mm");
        clock.text = label;
    }
}
