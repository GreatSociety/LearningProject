using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SmartphoneButtonController : MonoBehaviour
{

    [SerializeField] public GameObject WorkPanel;
    [SerializeField] public GameObject EditorPanel;

    private void Awake()
    {
        ButtonDoubleClick.ToEditor += ToEditorPanel;
    }

    public void Unlock()
    {
        WorkPanel.SetActive(true);
    }

    public void ToWorkPanel()
    {
        EditorPanel.SetActive(false);
    }

    private void ToEditorPanel()
    {
        EditorPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        ButtonDoubleClick.ToEditor -= ToEditorPanel;
    }
}
