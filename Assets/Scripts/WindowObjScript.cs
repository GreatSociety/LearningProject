using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowObjScript : MonoBehaviour, ObjectInterface
{
    [SerializeField] public Animator openCloseAnim;
    [SerializeField] BreakableWindow leftframe;
    [SerializeField] BreakableWindow rightframe;


    private string parameter = "IsOpening";
    private bool state = false;

    // Start is called before the first frame update
    void Start()
    {
        openCloseAnim.SetBool(parameter, state);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // We Should write some interface
        
            
        
    }
    private void AnimConroller()
    {
        state = !state;

        openCloseAnim.SetBool(parameter, state);
    }

    public void Interactive(bool on)
    {
        if (on)
        {
            AnimConroller();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            leftframe.breakWindow();
            rightframe.breakWindow();
        }
    }
}
