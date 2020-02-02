using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fourthCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") collision.gameObject.GetComponentInParent<PlayerCollisions>().whichSpawn = 3;
    }
}
