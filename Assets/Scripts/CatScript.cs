using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    // Start is called before the first frame update
   private  Vector3 Endpoint;
   private int speed = 10; 
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SmatphoneInputControl.IsAllowed)
        {
            GetComponent<Animator>().SetBool("walk", true);
            Endpoint = new Vector3(42.0f, 0.1f, 28.0f);
            transform.position = Vector3.MoveTowards(transform.position, Endpoint, Time.deltaTime * speed);
        }
    }
    void Miau()
    {
        if (SafeScript.Opened) 
        {
            GetComponent<Animator>().SetBool("cat_armature|miau", true);
        }
       
    }
   
}
