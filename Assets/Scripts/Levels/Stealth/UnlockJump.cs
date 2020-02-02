﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockJump : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        other.GetComponentInParent<Movement>().canJump = true;
        Destroy(transform.gameObject);
    }
}
