using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool IsGrounded;
    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask GroundLayer;


    //------------------Actions-----------------------
    //------------------Jump Assist--------------------------
    [SerializeField] float JumpForce;
    bool Jump;
    bool jumpBuffer;
    [SerializeField] private float jumpBufferLength = 0.2f;
    private float jumpBufferTimer;
    [SerializeField] private float cayoteTimeLength = 0.1f;
    //------------------End-----------------------------------


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = Physics2D.OverlapCapsule(GroundCheck.transform.position, new Vector2(0.75f, 0.2f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
        if (IsGrounded == true)
        {
            cayoteTimeLength = 0.1f;
        }
        else
        {
            cayoteTimeLength -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpBuffer = true;
            jumpBufferTimer = jumpBufferLength;
            Jump = true;
        }
    }


    private void FixedUpdate()
    {
        if (jumpBuffer == true)
        {
            jumpBufferTimer -= Time.deltaTime;
            if (jumpBufferTimer > 0 && (cayoteTimeLength > 0 || (IsGrounded && Jump)))
            {
                jumpBuffer = false;
                rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);

                // Reset the jump buffer and cayote time states
                Jump = false;

            }
            else if (jumpBufferTimer <= 0)
            {
                jumpBuffer = false;
            }

        }
        if (jumpBuffer == false)
        {
            jumpBufferTimer = 0;
        }

    }
}
