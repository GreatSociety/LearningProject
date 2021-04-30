using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPointers : MonoBehaviour
{
    [SerializeField] GameObject pointerMinutes;
    [SerializeField] GameObject pointerHours;

    // Start is called before the first frame update
    void Start()
    {
        Clock.ClockPointers += ClockUpdate;
    }

    public void ClockUpdate(int hour, int minutes)
    {
        float rotationMinutes = (360.0f / 60.0f) * minutes;
        float rotationHours = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);
    }

    private void OnDestroy()
    {
        Clock.ClockPointers -= ClockUpdate;
    }
}
