using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject[] detectedSpawns = new GameObject[1];
    int whichSpawn = 0;

    private float counter = 0.0f;
    private float respawnTime = 1.0f;
    private bool caught = false;

    public RawImage gravityKey;
    public GameObject detectedText;

    private Color keyColor;

    private void Start()
    {
        keyColor = gravityKey.color;
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
        if(other.gameObject.tag == "GravityRoom")
        {
            keyColor.a = 1f;

            gravityKey.color = keyColor;
        }

        if (other.gameObject.tag == "Detection")
        {
            Detected();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GravityRoom")
        {
            keyColor.a = 0.3f;

            gravityKey.color = keyColor;
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

            Destroy(collision.gameObject);
        }
    }

    public void Detected()
    {
        detectedText.SetActive(true);

        gameObject.GetComponent<Movement>().rb.velocity = new Vector3(0, 0, 0);
        gameObject.GetComponent<Movement>().enabled = false;
        gameObject.GetComponentInChildren<CameraMovement>().enabled = false;

        caught = true;
    }

    void Respawn()
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
