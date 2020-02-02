using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject[] detectedSpawns = new GameObject[1];
    public int whichSpawn = 0;

    private float counter = 0.0f;
    private float respawnTime = 1.0f;
    public bool caught = false;

    public GameObject cross;
    public GameObject detectedText;
    public GameObject gun;

    private Color keyColor;

    private void Start()
    {
    }

    private void Update()
    {
        if(caught)
        {
            counter += Time.deltaTime;
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Detection" && !GetComponent<PlayerCrouch>().crouching)
        {
            Detected();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GravityRoom")
        {
            keyColor.a = 0.3f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BodyPart")
        {
            if(collision.gameObject.name.Equals("Eyes(Clone)"))
            {
                Debug.Log("You got eyes");
            }

            if(collision.gameObject.name == "Brain")
            {
                Debug.Log("You got brain");
            }
            if (collision.gameObject.name == "Gun")
            {
                gun.SetActive(true);
                cross.SetActive(true);
                GetComponent<PlayerRaycastShoot>().enabled = true;
                Debug.Log("You got gun");
            }

            FindObjectOfType<AudioManager>().Play("PartCollection");

            if(SceneManager.GetActiveScene().name != "Gravity") Destroy(collision.gameObject);
        }
    }

    public void Detected()
    {
        FindObjectOfType<AudioManager>().Play("DetectedSound");
        detectedText.SetActive(true);

        gameObject.GetComponent<Movement>().rb.velocity = new Vector3(0, 0, 0);
        gameObject.GetComponent<Movement>().enabled = false;
        gameObject.GetComponentInChildren<CameraMovement>().enabled = false;

        caught = true;
    }

    public void Respawn()
    {
        if(counter > respawnTime)
        {
            gameObject.transform.position = detectedSpawns[whichSpawn].transform.position;

            detectedText.SetActive(false);

            gameObject.GetComponent<Movement>().enabled = true;
            gameObject.GetComponentInChildren<CameraMovement>().enabled = true;

            caught = false;

            counter = 0.0f;
        }
    }
}
