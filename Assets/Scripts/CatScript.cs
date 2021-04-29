using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    // Start is called before the first frame update
    /*private  Vector3 Endpoint;
    private float speed = 2.0f;
     private Vector3 Endpoint1;
     private bool Endpoint1state = false;
    */
    public int moveingTo = 0;
    public int movementDirection = 1;
    public Transform[] PathElements;

    
    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathElements == null || PathElements.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return PathElements[moveingTo];
            if (PathElements.Length == 1)
            {
                continue;
            }
            if (PathElements.Length > 1)
            {
                if (moveingTo <= 0)
                {
                    movementDirection = 1;

                }
                else if (moveingTo >= PathElements.Length - 1)
                {
                    movementDirection = -1;
                }
            }
            moveingTo += movementDirection;
        }
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
            /* Endpoint1 = new Vector3(48.0f, 0.1f, 28.0f );
             transform.position = Vector3.MoveTowards(transform.position, Endpoint1, Time.deltaTime * speed);
             Endpoint1state = true;
             if (Endpoint1state == true) 
             {
                 Endpoint = new Vector3(42.0f, 0.1f, 28.0f);
                 transform.position = Vector3.MoveTowards(transform.position, Endpoint, Time.deltaTime * speed);
             }

         }
         if (SafeScript.Opened)
         {
             Miau(); 
         }
     }
     void Miau()
     {
         GetComponent<Animator>().Play("cat_armature_miau");
     } */
        
    }
    void Walking()
    {
        GetComponent<Animator>().SetBool("start walking", true);
    }
    
    //
    

 

    
}
  






