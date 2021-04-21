using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISave 
{
    
    void Save();
}

public interface ILoad
{
    string Load();
}

public interface IWrite
{
    void Write();
}

public interface IRead
{
    void Read();
}
