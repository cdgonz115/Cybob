using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockCrouch : MonoBehaviour
{
    public RawImage key;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInParent<PlayerCrouch>().canCrouch = true;
        key.color = new Color(0, 0, 0, 255f);
        other.GetComponentInParent<PlayerCollisions>().whichSpawn = 1;
        Destroy(transform.gameObject);
    }
}
