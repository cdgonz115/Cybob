﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.z > 70f) transform.position = new Vector3(transform.position.x, transform.position.y, -70f);
        transform.position += new Vector3(0,0,2f);
    }
}
