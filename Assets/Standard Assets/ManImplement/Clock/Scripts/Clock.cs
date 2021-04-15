using UnityEngine;
using System.Collections;
using System;
using System.Text;

public class Clock : MonoBehaviour {
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Simple Clock Script / Andre "AEG" Bürger / VIS-Games 2012
    //
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------

    //-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;
    public int seconds;

    // Events 

    public static Action<StringBuilder> TextTime;
    public static Action<int> LightTime;

    //-- time speed factor
    public float clockSpeed = 12.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    float msecs;
    int temp;

    [HideInInspector] public StringBuilder ToPhone;

    [SerializeField] GameObject pointerMinutes;
    [SerializeField] GameObject pointerHours;
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
void Start() 
{

    minutes = DateTime.Now.Minute;
    hour = DateTime.Now.Hour;
    seconds = DateTime.Now.Second;
    msecs = 0.0f;

    ToPhone = new StringBuilder($"{hour}:{minutes}", 7);
    LightTime?.Invoke(hour);
}
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
void Update() 
{
    temp = minutes;
    
    //-- calculate time
    msecs += Time.deltaTime * clockSpeed;

    if(msecs >= 1.0f)
    {
        msecs -= 1.0f;
        seconds++;
        if(seconds >= 60)
        {
            seconds = 0;
            minutes++;
            if(minutes > 60)
            {
                minutes = 0;
                hour++;
                if(hour >= 24)
                    hour = 0;

                LightTime?.Invoke(hour);
            }
        }
    }

    if (temp != minutes)
        PhoneTime();

    //-- calculate pointer angles
    //float rotationSeconds = (360.0f / 60.0f)  * seconds;
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

    //-- draw pointers
    //pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
    pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);

}


void PhoneTime()
{
        ToPhone.Clear();

        ToPhone.Append(minutes > 9 ? $"{hour}:{minutes}" : $"{hour}:0{minutes}");
}

//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
}

