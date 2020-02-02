using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{

    public CapsuleCollider standCollider => GetComponent<CapsuleCollider>();

    public bool canCrouch = true;

    private Vector3 standCamPOS;
    private Vector3 crouchCamPOS;

    private float standY;
    private float crouchY;

    private Camera playerCam => gameObject.GetComponentInChildren<Camera>();
    private float camX;
    private float camZ;

    private Vector3 originalCenter;
    private float originalHeight;
    private float orginalMovespeed;

    private void Start()
    {
        camX = playerCam.transform.localPosition.x;
        camZ = playerCam.transform.localPosition.z;

        standY = playerCam.transform.localPosition.y;

        crouchY = standY - (standY / 2);

        standCamPOS = new Vector3(camX, standY, camZ);
        crouchCamPOS = new Vector3(camX, crouchY, camZ);

        originalCenter = standCollider.center;
        originalHeight = standCollider.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(canCrouch)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Crouch();
            }
            if(Input.GetKeyUp(KeyCode.LeftControl))
            {
                StandUp();
            }
        }
    }

    void Crouch()
    {
        standCollider.height = (originalHeight / 2) + 1;
        standCollider.center = new Vector3(originalCenter.x, originalCenter.y - 1, originalCenter.z);

        playerCam.transform.localPosition = crouchCamPOS;
    }

    void StandUp()
    {
        Vector3 point0 = standCollider.transform.position + originalCenter - new Vector3(0.0f, originalHeight, 0.0f);
        Vector3 point1 = standCollider.transform.position + originalCenter + new Vector3(0.0f, originalHeight, 0.0f);

        if (Physics.OverlapCapsule(point0, point1, standCollider.radius).Length <= 2)
        {
            standCollider.height = originalHeight;
            standCollider.center = originalCenter;
            playerCam.transform.localPosition = standCamPOS;
        }
    }
}
