using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevel : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Gravity");
        }
    }
}
