using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMoveingPathScript : MonoBehaviour
{
    public CatPatScript MyPath;
    private float speed = 1.0f;
    private float MaxDistance = 0.1f;
    private IEnumerator<Transform> pointInPath;
   
    void Start()
    {
        
        

            if (MyPath == null)
            {
                return;
            }
            pointInPath = MyPath.GetNextPathPoint();

            pointInPath.MoveNext();

            if (pointInPath.Current == null)
            {

                return;
            }
            transform.localPosition = pointInPath.Current.localPosition;
        
    }


    void Update()
    {
        if (SmatphoneInputControl.IsAllowed)
        {
            Moveing();
           
        }
    }
    void Moveing()
    {
        GetComponent<Animator>().SetBool("start walking", true);
        
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, pointInPath.Current.localPosition, Time.deltaTime * speed);
        var distanceSquare = (transform.localPosition - pointInPath.Current.localPosition).sqrMagnitude;
        if (distanceSquare < MaxDistance * MaxDistance)
        {
            transform.Rotate(0, 90, 0);
            pointInPath.MoveNext();
        }

        if (pointInPath == null || pointInPath.Current == null)
        {
            GetComponent<Animator>().SetBool("stop", true);
            return;

        }
    }
    
}
