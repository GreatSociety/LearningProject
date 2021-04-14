using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ButtonDoubleClick : MonoBehaviour, IPointerClickHandler
{
    public static event Action ToEditor;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount > 1)
            ToEditor?.Invoke();
    }
}
