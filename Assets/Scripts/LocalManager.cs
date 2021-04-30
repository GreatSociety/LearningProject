using UnityEngine;
using UnityEngine.Localization.Settings;
using Newtonsoft.Json.Linq;

public class LocalManager : MonoBehaviour
{
    private void Awake()
    {

        //DontDestroyOnLoad(gameObject);
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
