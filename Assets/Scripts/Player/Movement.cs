using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public string verticalInput = "Vertical";
    public string horizontalInput = "Horizontal";
    [SerializeField] private KeyCode jumpKey;
    public float runSpeed;
    public float movementSpeed = 4;
    public float gravityCoefficient;
    public float fallCoefficent;
    public float jumpStrength;
    public float timer;
    public float frictionCoefficient;
    public bool forwardUnlocked;
    private bool jumping;
    public bool grounded = true;
    private float gravity;
    public int jumps = 10;
    public bool canJump = false;
    public CapsuleCollider playerCollider;

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
        if (grounded && !Physics.Raycast(playerCollider.bounds.center, Vector3.down, playerCollider.bounds.extents.y + 0.5f))
        {
            gravity = fallCoefficent;
            grounded = false;
        }
        JumpInput();
    }
    private void movement()
    {
        Vector3 lateral = transform.right * (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) ? Input.GetAxis(horizontalInput) : 0);
        Vector3 forward = transform.forward * (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ? Input.GetAxis(verticalInput) : 0);

        rb.velocity = (forwardUnlocked ? (forward + lateral).normalized : (lateral).normalized) * (Input.GetKey(KeyCode.LeftShift) ? runSpeed : movementSpeed) + new Vector3(0, rb.velocity.y, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Vector3.Dot(collision.contacts[0].normal, Vector3.up) > 0.05)
        {
            grounded = true;
            gravity = 0;
            jumps = 1;
        }
    }

    private void JumpInput()
    {

        if (Input.GetKeyDown(jumpKey) && jumps > 0 && canJump)
        {
            rb.AddForce(new Vector3(0, jumpStrength * 100, 0));
            //b.velocity = new Vector3(rb.velocity.x, jumpStrength, rb.velocity.z);
            rb.velocity /= frictionCoefficient;
            jumps--;
        }
        else if (!grounded)
        {
                if (gravity < fallCoefficent * 4) gravity /= gravityCoefficient;
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - gravity, rb.velocity.z);
        }

    }
}
