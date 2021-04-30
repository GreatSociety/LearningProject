using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeScript : MonoBehaviour, ObjectInterface, ISave
{
    public Canvas CanvasSafe;
    SaveLoad Safe = new SaveLoad("Safe");

    private int number1 = 1;
    private int number2 = 1;
    private int number3 = 1;
    private int number4 = 1;

    public Text TextNumber1;
    public Text TextNumber2;
    public Text TextNumber3;
    public Text TextNumber4;

    public static bool Opened = false;

    public void Awake()
    {
        AppendToSaveble();
        Load();
    }


    public void Interactive(KeyCode key, Transform player)
    {
        if (key == KeyCode.E)
        {
            if (!CanvasSafe.gameObject.activeSelf)
            {
                CanvasSafe.gameObject.SetActive(true);
                return;
            }


            CanvasSafe.enabled = !CanvasSafe.enabled;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = !Cursor.visible;
        }
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
            Opened = true;
        }
        if (Opened == true)
        {
            UnlockSafe();
        }
    }

    void UnlockSafe()
    {
        GetComponent<Animator>().SetBool("SafeCode", true);
    }

    public void Load()
    {
        if (Safe.Load() == null)
            return;

        gameObject.transform.position = Safe.Load().transform;
        Opened = Safe.Load().flag;
    }

    public void Save()
    {
        Safe.Save(new Temp(gameObject.transform.position, Opened));
    }
    public void AppendToSaveble()
    {
        SaveManager.SavableList.Add(this);
    }

    public void DeleteOnDestroy()
    {
        SaveManager.SavableList.Remove(this);
    }

    void OnDestroy()
    {
        DeleteOnDestroy();
    }
}
