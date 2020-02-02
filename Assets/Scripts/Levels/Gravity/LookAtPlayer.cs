using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;
    public Camera camera1;
    public Camera camera2;
    private void FixedUpdate()
    {
        if (player.transform.position.z > 47)
        {
            camera1.enabled=false;
            camera2.enabled=true;
        }
        transform.LookAt(player.transform.position);
    }
}
