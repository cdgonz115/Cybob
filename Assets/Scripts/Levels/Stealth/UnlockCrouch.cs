using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockCrouch : MonoBehaviour
{
    public RawImage key;
    private Color tempColor;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("PartCollection");
        tempColor = key.color;
        tempColor.a = 255f;
        other.GetComponentInParent<PlayerCrouch>().canCrouch = true;
        key.color = tempColor;
        other.GetComponentInParent<PlayerCollisions>().whichSpawn = 1;
        Destroy(transform.gameObject);
    }
}
