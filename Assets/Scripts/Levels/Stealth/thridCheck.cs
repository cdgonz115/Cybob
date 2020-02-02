using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") other.GetComponent<PlayerCollisions>().whichSpawn = 2;
    }
}
