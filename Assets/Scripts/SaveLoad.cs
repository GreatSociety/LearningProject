using Newtonsoft.Json;

public class SaveLoad 
{
    string propName;

    public SaveLoad(string propName)
    {
        this.propName = propName;
    }

    public void Save(Temp temp)
    {
        if (SaveManager.Data[propName] != null)
            SaveManager.Data[propName] = JsonConvert.SerializeObject(temp);
        else
            SaveManager.Data.Add(propName, JsonConvert.SerializeObject(temp));

    }

    public Temp Load()
    {
        if ((string)SaveManager.Data.GetValue(propName) == null)
            return null;

        return JsonConvert.DeserializeObject<Temp>((string)SaveManager.Data.GetValue(propName));
    }
}
