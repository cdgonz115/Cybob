using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    Vector3 playerPOS;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerCollisions>().Detected(gameObject.transform.position);
            playerPOS = other.gameObject.transform.position;

            GetComponentInParent<EnemyEnd>().Attack(playerPOS);
        }
    }
}
