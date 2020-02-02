using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCrouch : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        other.GetComponentInParent<PlayerCrouch>().canCrouch = true;
        Destroy(transform.gameObject);
    }
}
