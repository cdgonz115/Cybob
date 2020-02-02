using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StayInZone : MonoBehaviour
{
    public float timer;
    public bool inside=false;
    public bool forward = false;
    public int flashing;
    public GameObject textTime;
    public GameObject crosshair;
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject wKey;
    public GameObject sKey;
    public GameObject player;

    public void Start()
    {
       crosshair.SetActive(false);
       textTime.GetComponent<Text>().text = timer + "/3";
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") timer += Time.deltaTime;
        TimerUI();
    }
    private void OnTriggerExit(Collider other)
    {
        inside = false;
        if (System.Math.Round(timer, 5) >= 3 && !forward) changeCamera();
        timer = 0;
    }
    public void TimerUI()
    {
        textTime.GetComponent<Text>().text = System.Math.Round(timer,5) + "/3";
    }
    public void changeCamera()
    {
        forward = true;

        camera1.GetComponent<Camera>().orthographic = false;

        light1.GetComponent<Light>().enabled = true;
        light2.GetComponent<Light>().enabled = true;
        light3.GetComponent<Light>().enabled = true;
        light1.GetComponent<MoveLight>().enabled = true;
        light2.GetComponent<MoveLight>().enabled = true;
        light3.GetComponent<MoveLight>().enabled = true;
        GetComponent<MeshRenderer>().enabled = false;

        wKey.GetComponent<RawImage>().CrossFadeAlpha(255f, 60, true);
        sKey.GetComponent<RawImage>().CrossFadeAlpha(255f, 60, true);
        textTime.SetActive(false);
        player.GetComponent<Movement>().forwardUnlocked = true;
    }
    private void FixedUpdate()
    {
        if(forward)camera1.transform.position=Vector3.MoveTowards(camera1.transform.position, new Vector3(7.68f,-1.73f,-44),3f);
        if (player.transform.position.z >0)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
    }


}
