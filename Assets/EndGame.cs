using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject player;
    public GameObject glass;
    public GameObject skin;
    public GameObject brain;
    private Vector3 playerL;
    private void OnTriggerEnter(Collider other)
    {
        GameObject [] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int size = enemies.Length;
        for (int x = 0; x < size; x++)
        {
            enemies[x].SetActive(false);
        }
        playerL = player.transform.position;
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<PlayerRaycastShoot>().enabled = false;
        player.GetComponent<PlayerCrouch>().enabled = false;
        player.GetComponent<PlayerCollisions>().enabled = false;
        skin.SetActive(false);

        StartCoroutine("WinGame");
    }
    IEnumerator WinGame()
    {
        for (int x = 0; x < 360; x++)
        {
            yield return new WaitForEndOfFrame();
        }
        glass.SetActive(false);
        for (int x = 0; x < 360; x++)
        {
            brain.transform.position = Vector3.MoveTowards(brain.transform.position,playerL,1f);
            yield return new WaitForEndOfFrame();
        }



    }
}
