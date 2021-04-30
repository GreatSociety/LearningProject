using UnityEngine;
using UnityEngine.Localization.Settings;
using Newtonsoft.Json.Linq;

public class LocalManager : MonoBehaviour
{
    static LocalManager instance;

    private void Awake()
    {

        if (LocalManager.instance == null)
        {
            DontDestroyOnLoad(this);
            LocalManager.instance = this;

        }
        else
        {
            Destroy(this.gameObject);
        }

        SaveManager.SettingLoad += Set;

    }

    void ChangeLang(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    void Set(JObject setting)
    {
        ChangeLang((int)setting["Lang"]);
    }
}
