using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    float spinSpeed;
    Vector3 rotation;

    bool atTop;
    float bobSpeed;
    Vector3 targetY;
    Vector3 originalY;
    Vector3 currentPOS;

    // Start is called before the first frame update
    void Start()
    {
        atTop = false;
        bobSpeed = 0.8f;
        originalY = gameObject.transform.position;
        targetY = new Vector3(originalY.x, originalY.y + 2, originalY.z);

        spinSpeed = 0.5f;
        rotation = new Vector3(0, spinSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotation);

        currentPOS = gameObject.transform.position;

        Bobbing();
    }

    void Bobbing()
    {
        if(!atTop)
        {
            if(Vector3.Distance(currentPOS, targetY) > 0)
            {
                Movement(targetY);
            }
            else
            {
                atTop = true;
            }
        }
        else
        {
            if(Vector3.Distance(currentPOS, originalY) > 0)
            {
                Movement(originalY);
            }
            else
            {
                atTop = false;
            }
        }
    }

    void Movement(Vector3 _target)
    {
        gameObject.transform.position = Vector3.MoveTowards(currentPOS, _target, bobSpeed * Time.deltaTime);
    }
}
