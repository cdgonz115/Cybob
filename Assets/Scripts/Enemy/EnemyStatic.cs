using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    public float turnSpeed = 5.0f;
    public float pauseTIme = 1.0f;
    private float multi = 10f;
    private float counter = 0f;

    public float goal = 180f;
    private Quaternion myAngle;
    private float initial;

    bool otherWay = false;

    // Start is called before the first frame update
    void Start()
    {
        initial = transform.rotation.eulerAngles.y;
        myAngle = Quaternion.Euler(0f, initial + goal, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, myAngle, turnSpeed * multi * Time.fixedDeltaTime);

        CheckRotation();
    }

    void CheckRotation()
    {
        if(Quaternion.Angle(transform.rotation, myAngle) <= 1)
        {
            if(counter > pauseTIme)
            {
                if (!otherWay)
                {
                    myAngle = Quaternion.Euler(0f,initial, 0f);
                    otherWay = true;
                }
                else
                {
                    myAngle = Quaternion.Euler(0f,initial+ goal, 0f);
                    otherWay = false;
                }
                counter = 0f;
            }
            else
            {
                counter += Time.deltaTime;
            }
        }
    }
}
