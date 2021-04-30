using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPatScript : MonoBehaviour
{
    private int moveingTo = 0;
    private int movementDirection = 1;
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
            moveingTo = moveingTo + movementDirection;


        }
    }

   
}
