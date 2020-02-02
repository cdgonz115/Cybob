using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockJump : MonoBehaviour
{
    public RawImage key;
    private Color tempColor;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("PartCollection");
        tempColor = key.color;
        tempColor.a = 255f;

        other.GetComponentInParent<Movement>().canJump = true;
        key.color = tempColor;
        Destroy(transform.gameObject);
    }
}
