using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public string verticalInput;
    public string horizontalInput;
    public float runSpeed;
    public float movementSpeed;
    public float timer;
    public bool forwardUnlocked;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
    }
    private void movement()
    {
        Vector3 lateral = transform.right * (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) ? Input.GetAxis(horizontalInput) : 0);
        Vector3 forward = transform.forward * (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ? Input.GetAxis(verticalInput) : 0);

        rb.velocity = (forwardUnlocked ? (forward + lateral).normalized : (lateral).normalized) * (Input.GetKey(KeyCode.LeftShift) ? runSpeed : movementSpeed) + new Vector3(0, rb.velocity.y, 0);
    }

}
