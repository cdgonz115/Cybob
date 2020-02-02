using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeCamera : MonoBehaviour
{
    public float zLocation;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(7.68f, -1.73f, zLocation), 3f);
    }
}
