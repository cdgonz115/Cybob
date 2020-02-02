using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StayInZone : MonoBehaviour
{
    public float timer;
    public bool inside=false;
    public bool forward = false;
    public Text textTime;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") timer += Time.deltaTime;
    }
    private void OnTriggerExit(Collider other)
    {
        inside = false;
        timer = 0;
    }
    private void Update()
    {
        if (timer >= 4) forward = true;

    }
    public void Timer()
    { 
    
    
    }
}
