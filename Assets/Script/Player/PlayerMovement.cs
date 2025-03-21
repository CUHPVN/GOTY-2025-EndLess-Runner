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
    //------------------End-----------------------------------


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        IsGrounded = Physics2D.OverlapCapsule(GroundCheck.transform.position, new Vector2(0.75f, 0.2f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }
    }

}
