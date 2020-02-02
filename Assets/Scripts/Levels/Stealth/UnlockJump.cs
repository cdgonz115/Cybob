using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockJump : MonoBehaviour
{
    public RawImage key;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInParent<Movement>().canJump = true;
        key.color = new Color(0,0,0,255f);
        Destroy(transform.gameObject);
    }
}
