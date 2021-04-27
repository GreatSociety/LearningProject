using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSystemScript : MonoBehaviour
{
    public static bool isSafeVisible = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSafeVisible)
        {
            GetComponent<Animator>().SetBool("ActiveMove", true);
        }
    }
}
