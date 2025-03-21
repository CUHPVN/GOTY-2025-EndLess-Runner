using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float JumpStrength;
    Rigidbody rb;
    bool Jump;
    Transform GroundCheck;
    [SerializeField]
    LayerMask GroundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //bool isGrounded = Physics.OverlapCapsule(GroundCheck.transform.position, )

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Jump = true;
        }

    }
    private void FixedUpdate()
    {
        if (Jump)
        {
            rb.AddForce(transform.up * JumpStrength, ForceMode.Impulse);
            Jump = false;
        }

    }
}
