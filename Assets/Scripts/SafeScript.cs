using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeScript : MonoBehaviour, ObjectInterface
{
    public Canvas CanvasSafe;
    private int number1 = 1;
    private int number2 = 1;
    private int number3 = 1;
    private int number4 = 1;

    public Text TextNumber1;
    public Text TextNumber2;
    public Text TextNumber3;
    public Text TextNumber4;

    public bool opened;
    public void Interactive(KeyCode key, Transform player)
    {
        if (key == KeyCode.E)
        {
            CanvasSafe.enabled = !CanvasSafe.enabled;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = !Cursor.visible;
        }

    }

    void Start()
    {
        CanvasSafe.enabled = false;
        opened = false;
    }
    

    public void IncreaseNumber(int number)
    {
        if (number == 1)
        {
            number1++;
            TextNumber1.text = number1.ToString();
            if (number1 > 9)
            {
                number1 = 1;
                TextNumber1.text = number1.ToString();
            }
        }
        else if (number == 2) 
        {
            number2++;
            TextNumber2.text = number2.ToString();
            if (number2 > 9)
            {
                number2 = 1;
                TextNumber2.text = number2.ToString();
            }
        }
        else if (number == 3)
        {
            number3++;
            TextNumber3.text = number3.ToString();
            if (number3 > 9)
            {
                number3 = 1;
                TextNumber3.text = number3.ToString();
            }
        }
        else if (number == 4)
        {
            number4++;
            TextNumber4.text = number4.ToString();
            if (number4 > 9)
            {
                number4 = 1;
                TextNumber4.text = number4.ToString();
            }
        }
    }
    void Update() 
    {
        if (number1 == 3 && number2 == 7 && number3 == 2 && number4 == 5) 
        {
            opened = true;
        }
        if (opened == true) 
        {
            UnlockSafe();
        }
    }

    void UnlockSafe() 
    {
    
    }
}
