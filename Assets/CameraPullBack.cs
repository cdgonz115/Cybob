using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPullBack : MonoBehaviour
{
    public GameObject toGo;
    public float speed;
    public Image screen;
    public float timer;
    public bool once = false;
    public bool twice = false;
    private void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, toGo.transform.position, speed);
        if (timer >= 15 && !once)
        {
            screen.CrossFadeAlpha(255f, 10, false);
            once = true;
        }
        if (timer >= 25 && !twice) 
        {
            twice = true;
            Application.Quit();
        }
    }

}
