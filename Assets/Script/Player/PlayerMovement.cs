using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool IsGrounded;
    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask GroundLayer;
    StateManager StM;

    [SerializeField] float JumpForce;
    [SerializeField] float FlyForce;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StM = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (StM.GetState())
        {
            case StateManager.States.JumpState:
                Move();
                break;
            case StateManager.States.FlyState:
                Fly();
                break;
            default:
                break;
        }
    }
    private void Move()
    {
        IsGrounded = Physics2D.OverlapCapsule(GroundCheck.transform.position, new Vector2(0.75f, 0.2f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }
    }
    private void Fly()
    {
        if (rb.linearVelocityY > 15f)
        {
            rb.linearVelocityY = 15f;
        }
        else if (rb.linearVelocityY < -15f)
        {
            rb.linearVelocityY = -15f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.gravityScale = -1;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

}
