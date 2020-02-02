using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInParent<PlayerCollisions>().whichSpawn = 2;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
