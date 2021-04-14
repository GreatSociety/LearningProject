using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowObjScript : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            AnimConroller();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            leftframe.breakWindow();
            rightframe.breakWindow();
        }
            
        
    }
    private void AnimConroller()
    {
        state = !state;

        openCloseAnim.SetBool(parameter, state);
    }
}
