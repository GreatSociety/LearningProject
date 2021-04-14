using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SmartphoneButtonController : MonoBehaviour
{

    [SerializeField] public SmartphoneObjScript inHandflag;
    [SerializeField] public GameObject WorkPanel;
    [SerializeField] public GameObject EditorPanel;

    private void Start()
    {
        ButtonDoubleClick.ToEditor += ToEditorPanel;
    }

    void FixedUpdate()
    {
        if(inHandflag.onHand)
            if (Input.GetKeyDown(KeyCode.F))
            {
                WorkPanel.SetActive(true);
            }

        if(!inHandflag.onHand)
            ToWorkPanel();
        
    }

    public void ToWorkPanel()
    {
        EditorPanel.SetActive(false);
    }

    private void ToEditorPanel()
    {
        EditorPanel.SetActive(true);
    }
}
