using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idiot : MonoBehaviour
{
    public GameObject dude;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            dude.GetComponent<PlayerCollisions>().caught = true ;
        }
    }
}
