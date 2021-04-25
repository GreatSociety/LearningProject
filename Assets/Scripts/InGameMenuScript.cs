using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Canvas))]

public class InGameMenuScript : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject PromtPanel;
    [SerializeField] GameObject SettingsPanel;

    Canvas Menu;

    // Start is called before the first frame update
    void Start()
    {
        Menu = GetComponent<Canvas>();
        StartCoroutine(QuickStartPromt());
        InputManager.KeyDown += MenuCall;
    }

    IEnumerator QuickStartPromt()
    {

        yield return new WaitForSeconds(10);

        Destroy(PromtPanel);

        Menu.enabled = false;
        MenuPanel.SetActive(true);
    }

    void MenuCall(KeyCode esc)
    {
        if (esc != KeyCode.Escape)
            return;

        Menu.enabled = !Menu.enabled;
    }

}
