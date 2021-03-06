﻿using UnityEngine;
using System.Collections;

public class DayCycle_Manager : MonoBehaviour {

    public Light sun;
    public float dayLengthInSeconds = 120f;
    [Range( 0, 1 )]
    public float currentTimeOfDay = 0f;
    public float timeMultiplier = 2f;

    float sunInitialIntensity;

    private bool isDay;

	// Use this for initialization
	void Start () {
        sunInitialIntensity = sun.intensity;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSun();

        if( currentTimeOfDay < 0.25 || currentTimeOfDay > 0.75 )
        {
            isDay = false;
        }
        else
        {
            isDay = true;
        }

        if( currentTimeOfDay <= 0.25f || currentTimeOfDay >= 0.75f )
        {
            currentTimeOfDay += (Time.deltaTime / dayLengthInSeconds * timeMultiplier);
        }
        else
        {
            currentTimeOfDay += (Time.deltaTime / dayLengthInSeconds);
        }

        if(currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
	}

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler( (currentTimeOfDay * 360f) - 90, -90, 0 );

        float intensityMultiplier = 1;
        if( currentTimeOfDay <= 0.25f || currentTimeOfDay >= 0.75f )
        {
            intensityMultiplier = 0;
        }
        else if(currentTimeOfDay <= 0.27)
        {
            intensityMultiplier = Mathf.Clamp01( (currentTimeOfDay - 0.25f) * (1 / 0.02f) );
        }
        else if(currentTimeOfDay >= 0.73)
        {
            intensityMultiplier = Mathf.Clamp01( (currentTimeOfDay - 0.73f) * (1 / 0.02f) );
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }

    public bool IsDay()
    {
        return isDay;
    }
}
