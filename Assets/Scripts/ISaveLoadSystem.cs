using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public interface ISave
{
    void Save();
    void Load();
    void AppendToSaveble();

    void DeleteOnDestroy();

}

public class Temp
{
    public Vector3 transform { get; set; }
    public bool flag { get; set; }

    public Temp(Vector3 transform, bool flag = false)
    {
        this.transform = transform;
        this.flag = flag;
    }
}