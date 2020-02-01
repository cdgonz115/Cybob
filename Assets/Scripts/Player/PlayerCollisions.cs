using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    public RawImage gravityKey;

    private Color keyColor;

    private void Start()
    {
        keyColor = gravityKey.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "GravityRoom")
        {
            keyColor.a = 1f;

            gravityKey.color = keyColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GravityRoom")
        {
            keyColor.a = 0.3f;

            gravityKey.color = keyColor;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
        }
    }
}
