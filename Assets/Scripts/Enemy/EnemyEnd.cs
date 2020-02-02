using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnd : MonoBehaviour
{
    bool attackPlayer = false;

    Vector3 playerPOS;

    private float speed = 2.0f;

    private void Update()
    {
        if (attackPlayer)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerPOS, speed * Time.deltaTime);
        }
    }

    public void Attack(Vector3 player)
    {

        gameObject.transform.LookAt(player);

        attackPlayer = true;
    }
}
