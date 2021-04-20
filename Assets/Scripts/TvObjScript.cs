using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TvObjScript : MonoBehaviour, ObjectInterface
{
    [SerializeField] private VideoPlayer tvScreen;

    public void Interactive(KeyCode key, Transform player)
    {
        if (key == KeyCode.E)
        {
            tvScreen.enabled = !tvScreen.enabled;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tvScreen.enabled = false;
    }
}
