using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class goToScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject room;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject zone;
    public GameObject player;
    public GameObject eye;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            room.GetComponent<RotateRoom>().enabled = false;
            zone.GetComponent<StayInZone>().enabled = false;
            camera1.SetActive(false);
            transform.localScale = new Vector3(1,1,1);
            transform.position = new Vector3(1.26f,-15.44f, 42.68f);
            player.SetActive(false);
            camera2.SetActive(true) ;
            StartCoroutine("eyeScene");
        }
    }
    IEnumerator eyeScene()
    {
        for (int x = 0; x < 360; x++)
        {
            if (x ==70) eye.SetActive(true);
            if (x ==80) eye.SetActive(false);
            if (x ==140) eye.SetActive(true);
            if (x ==150) eye.SetActive(false);
            if (x ==200) eye.SetActive(true);
            if (x ==210) eye.SetActive(false);
            if (x ==250) eye.SetActive(true);
            if (x ==260) eye.SetActive(false);
            if (x ==290) eye.SetActive(true);
            if (x ==300) eye.SetActive(false);
            if (x ==320) eye.SetActive(true);
            if (x ==330) eye.SetActive(false);
            if (x ==340) eye.SetActive(true);

            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene("Sneak");

    }
}
