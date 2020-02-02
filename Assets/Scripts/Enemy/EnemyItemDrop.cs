using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemDrop : MonoBehaviour
{
    public GameObject itemToDrop;

    public float myHealth = 100.0f;

    public void MyDamage(float _damage)
    {
        myHealth -= _damage;

        if(myHealth <= 0)
        {
            Vector3 spawnSpot = this.gameObject.transform.position;

            Destroy(this.gameObject);

            Instantiate(itemToDrop, spawnSpot, Quaternion.identity);
        }
    }
}
