using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class SmatphoneInputControl : MonoBehaviour
{
    public static bool IsAllowed = false;

    public string PreInput = "2002:";

    public string Answer = "room";

    [SerializeField] TMP_InputField InputField;

    void Start()
    {
        InputField.text = PreInput;
        InputField.onDeselect.AddListener(Check);
    }

    public void Check(string text)
    {
        if (text.ToLower().Contains(Answer.ToLower()))
            IsAllowed = true;
        
    }
}
