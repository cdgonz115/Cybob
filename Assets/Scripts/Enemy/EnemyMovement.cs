using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject[] patrolPoints = new GameObject[2];

    public float moveSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    private int targetPoint;
    private int maxPoints;

    private Vector3 currentPOS;

    bool facingObject;
    bool goForward;

    private Transform mainPoint;

    void Start()
    {
        facingObject = false; //checks if facing next point
        goForward = false; //which direction to traverse array

        targetPoint = 1; //2nd index in array is first point to go to

        maxPoints = patrolPoints.Length - 1; //gets max points so it can reverse
    }

    void Update()
    {
        currentPOS = gameObject.transform.position;

        MoveToPoint();
    }

    void MoveToPoint()
    {
        mainPoint = patrolPoints[targetPoint].transform; //transform of next point

        if(RotatedToPoint(mainPoint)) //checks if facing point
        {
            gameObject.transform.position = Vector3.MoveTowards(currentPOS, mainPoint.position, moveSpeed * Time.deltaTime); //moves to point

            CyclePoints(); //switches to next patrol point or reverses patrol
        }
    }

    bool RotatedToPoint(Transform _targetPoint)
    {
        if (Vector3.Angle(gameObject.transform.forward, _targetPoint.position - currentPOS) <= 1.5f) //checks if rotated close enough to point
        {
            facingObject = true;
        }
        else
        {
            facingObject = false;
        }

        if (!facingObject)
        {
            var targetRotation = Quaternion.LookRotation(_targetPoint.position - currentPOS); //goal of rotation
            var str = Mathf.Min(turnSpeed * Time.deltaTime, 1); //speed of rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str); //rotate enemy
        }

        return facingObject;
    }

    void CyclePoints()
    {
        if (Vector3.Distance(currentPOS, mainPoint.position) <= 0) //checks distance from patrol point
        {
            if (!goForward)
            {
                if (targetPoint == maxPoints)
                {
                    goForward = true;
                }
                else
                {
                    targetPoint++;
                }
            }
            else
            {
                if (targetPoint == 0)
                {
                    goForward = false;
                }
                else
                {
                    targetPoint--;
                }
            }
        }
    }
}
