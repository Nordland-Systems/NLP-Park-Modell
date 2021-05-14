using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    [SerializeField] private Material daySky;
    [SerializeField] private Material nightSky;
    [SerializeField] private bool nightTime;
    
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right,DayLightCycleValues.SPEED * Time.deltaTime);
        transform.LookAt(Vector3.zero);

        if (transform.rotation.x < 0)
        {
            if (!nightTime)
            {
                RenderSettings.skybox = nightSky;
                nightTime = true;
            }
        }
        else
        {
            if (nightTime)
            {
                RenderSettings.skybox = daySky;
                nightTime = false;
            }
        }
    }
}
