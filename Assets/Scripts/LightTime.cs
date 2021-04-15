using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightTime : MonoBehaviour
{
    Light Sun;

    int dayRotStep = 12;
    int nightRotStep = 20;

    int dayBorderMax = 21;
    int dayBorderMin = 6;

    int horizontalPosition = 70;

    void Start()
    {
        Sun = GetComponent<Light>();
        Clock.LightTime += XRotate;
    }

    void XRotate(int hour)
    {
        float rTime;

        if (hour > dayBorderMax)
        {
            rTime = hour - dayBorderMax;
            gameObject.transform.rotation = Quaternion.Euler(180 + rTime* nightRotStep, horizontalPosition, 0);
        }
        else if(hour < dayBorderMin)
        {
            rTime = 24 - (dayBorderMax - hour);
            gameObject.transform.rotation = Quaternion.Euler(180 + rTime * nightRotStep, horizontalPosition, 0);
        }
        else
        {
            rTime = hour - dayBorderMin;
            gameObject.transform.rotation = Quaternion.Euler(rTime * dayRotStep, horizontalPosition, 0);
        }

        MaskChanger(hour);

    }

    void MaskChanger(int hour)
    {
        if (hour > dayBorderMax || hour < dayBorderMin)
        {
            // Off
            Sun.cullingMask &= ~(1 << LayerMask.NameToLayer("Default"));
        }
        else
            // On
            Sun.cullingMask |= 1 << LayerMask.NameToLayer("Default");
    }

    void HideMask()
        => Sun.cullingMask &= ~(1 << LayerMask.NameToLayer("Default"));
    void ShowMask()
        => Sun.cullingMask |= 1 << LayerMask.NameToLayer("Default");
}
