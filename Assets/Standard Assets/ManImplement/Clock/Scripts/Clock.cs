using UnityEngine;
using System;
using System.Text;

public class Clock : MonoBehaviour {
    //-----------------------------------------------------------------------------------------------------------------------------------------
    
    public int minutes = 0;
    public int hour = 0;
    public int seconds;

    // Events 

    public static event Action<StringBuilder> TextTime;
    public static event Action<int> LightTime;
    public static event Action<int, int> ClockPointers;

    //-- time speed factor
    public float clockSpeed = 12.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    float msecs;
    int temp;

    [HideInInspector] public StringBuilder ToPhone;

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
    ClockPointers?.Invoke(hour, minutes);
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
            ClockPointers?.Invoke(hour, minutes);
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
}


void PhoneTime()
{
        ToPhone.Clear();
        ToPhone.Append(minutes > 9 ? $"{hour}:{minutes}" : $"{hour}:0{minutes}");
        TextTime?.Invoke(ToPhone);
}
}

