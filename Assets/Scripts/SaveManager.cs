using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;

public class SaveManager : MonoBehaviour, ILoad, ISave
{

    string jsonSetting;
    string jsonGameProgress;

    public string Load()
    {
        if (!File.Exists(jsonSetting))
            File.Open(jsonSetting, FileMode.OpenOrCreate);

        using (var fs = File.OpenText(jsonSetting))
        {
            var o = (new JsonTextReader(fs));
            return o.ToString();
        }
    }

    public void Save()
    {
        using (var fs = File.Open(jsonSetting, FileMode.OpenOrCreate))
        {
            
        }
    }

    void Awake()
    {
        jsonSetting = Path.Combine(Application.persistentDataPath, "Settings.json");
        jsonGameProgress = Path.Combine(Application.persistentDataPath, "GameProgress.json");

        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
