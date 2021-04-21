using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class TimeText : MonoBehaviour
{
    [SerializeField] TMP_Text TimePlace;

    void Start()
    {
        Clock.TextTime += TimeUpdate;
    }

    void TimeUpdate(StringBuilder time)
    {
        TimePlace.text = time.ToString();
    }

    
}
