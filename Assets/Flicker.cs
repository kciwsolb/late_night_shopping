using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker :MonoBehaviour
{
    private Light pointLight;
    private float changeTime;
    private float minTimeOn = 1.0f;
    private float maxTimeOn = 5.0f;
    private float maxTimeOff = 0.25f;


    private void Awake()
    {
        pointLight = GetComponent<Light>();
    }

    void Update()
    {
        if(Time.time > changeTime)
        {
            pointLight.enabled = !pointLight.enabled;
            if(pointLight.enabled)
            {
                changeTime = Time.time + Random.Range(minTimeOn, maxTimeOn);
            }
            else
            {
                changeTime = Time.time + Random.Range(0.0f, maxTimeOff);
            }
        }
    }
}
