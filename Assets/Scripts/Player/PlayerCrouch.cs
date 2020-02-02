using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{

    public CapsuleCollider standCollider;
    public CapsuleCollider crouchCollider;

    public bool canCrouch = true;

    private Vector3 standCamPOS;
    private Vector3 crouchCamPOS;

    private float standY;
    private float crouchY;

    private Camera playerCam => gameObject.GetComponentInChildren<Camera>();
    private float camX;
    private float camZ;

    private void Start()
    {
        camX = playerCam.transform.localPosition.x;
        camZ = playerCam.transform.localPosition.z;

        standY = playerCam.transform.localPosition.y;

        crouchY = standY - (standY / 2);

        standCamPOS = new Vector3(camX, standY, camZ);
        crouchCamPOS = new Vector3(camX, crouchY, camZ);
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
        playerCam.transform.localPosition = crouchCamPOS;
        crouchCollider.enabled = true;
        standCollider.enabled = false;
    }

    void StandUp()
    {
        playerCam.transform.localPosition = standCamPOS;
        standCollider.enabled = true;
        crouchCollider.enabled = false;
    }

    bool CheckSpace()
    {
        bool canStand = false;

        return canStand;
    }
}
