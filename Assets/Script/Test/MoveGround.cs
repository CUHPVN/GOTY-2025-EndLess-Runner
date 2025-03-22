using UnityEngine;

public class MoveGround : MonoBehaviour
{

    Rigidbody2D rb;
    public float GroundMoveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = GroundMoveSpeed;
    }
}
