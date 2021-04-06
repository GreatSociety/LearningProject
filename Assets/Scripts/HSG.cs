using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var bounds = gameObject.GetComponent<MeshFilter>().sharedMesh.bounds;
        Debug.Log($"{bounds} l");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
