using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastShoot : MonoBehaviour
{
    private Camera fpsCam => GetComponentInChildren<Camera>();

    public float damage = 100.0f;
    public float range = 100.0f;

    Quaternion gunRot;
    private float gunX;
    public GameObject myGun;

    private float gunRecoil = 15.0f;

    private void Start()
    {
        gunRot = myGun.transform.localRotation;

        gunX = gunRot.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();

            gameObject.GetComponentInChildren<AudioManager>().Play("Gunshot");

            myGun.transform.Rotate(new Vector3(gunX + gunRecoil, 0, 0));
        }

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            myGun.transform.Rotate(new Vector3(gunX - gunRecoil, 0, 0));
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Enemy")
            {
                EnemyHealth kill = hit.transform.GetComponent<EnemyHealth>();

                EnemyItemDrop kill2 = hit.transform.GetComponent<EnemyItemDrop>();

                if(kill != null)
                {
                    kill.TakeDamage(damage);
                }

                if(kill2 != null)
                {
                    kill2.MyDamage(damage);
                }
            }
        }
    }
}
