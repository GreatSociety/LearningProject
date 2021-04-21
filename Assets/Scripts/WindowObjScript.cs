using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WindowObjScript : MonoBehaviour, ObjectInterface
{
    [SerializeField] public Animator openCloseAnim;
    [SerializeField] BreakableWindow leftframe;
    [SerializeField] BreakableWindow rightframe;


    private string parameter = "IsOpening";
    private bool state = false;

    public bool isBreak;
    public event Action Breaking;

    // Start is called before the first frame update
    void Start()
    {
        openCloseAnim.SetBool(parameter, state);
    }
    private void AnimConroller()
    {
        state = !state;

        openCloseAnim.SetBool(parameter, state);
    }

    public void Interactive(KeyCode key, Transform player)
    {
        if (key == KeyCode.E)
        {
            AnimConroller();
        }

        if (key == KeyCode.Q)
        {
            if (isBreak)
                return;            

            leftframe.breakWindow();
            rightframe.breakWindow();

            isBreak = true;
            Breaking.Invoke();

        }
    }
}
