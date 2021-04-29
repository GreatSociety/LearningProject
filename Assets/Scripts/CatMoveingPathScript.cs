using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMoveingPathScript : MonoBehaviour
{
    public CatScript MyPath;
    public float speed = 1.0f;
    public float MaxDistance = 0.1f;
    private IEnumerator<Transform> pointInPath;
   
    void Start()
    {
        pointInPath = MyPath.GetNextPathPoint();
        pointInPath.MoveNext();
        if (pointInPath.Current == null)
        {
            return;
        }
        transform.position = pointInPath.Current.position;
    }


    void Update()
    {
        if (SmatphoneInputControl.IsAllowed)
        {

            if (pointInPath == null || pointInPath.Current == null)
            {
                return;
            }
            transform.Rotate(0,0,90);
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);

            var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
            if (distanceSquare < MaxDistance * MaxDistance)
            {
                pointInPath.MoveNext();
            }
        }
    }
}
