using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Bson;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class PlayerSaver : MonoBehaviour
{
    public void Save()
    {
        Temp playerTemp = new Temp
        {
            transform = gameObject.transform.position,
            flag = false

        };

        print(playerTemp.transform);

        SaveManager.Data.Add("Player", JsonConvert.SerializeObject(playerTemp));
    }

    public void Load()
    {
        Temp lol = JsonConvert.DeserializeObject<Temp>((string)SaveManager.Data.GetValue("Player"));
        print(lol.flag);
        print(lol.transform);
    }

    private void Awake()
    {
        Save();
    }

    private void OnDisable()
    {
        Load();
    }

}

public class Temp
{
    public Vector3 transform { get; set; }
    public bool flag { get; set; }
}
