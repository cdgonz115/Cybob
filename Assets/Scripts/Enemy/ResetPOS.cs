using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPOS : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
