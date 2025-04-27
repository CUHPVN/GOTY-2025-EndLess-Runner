using UnityEngine;

public class LevelMove : MonoBehaviour
{
		[SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Vector3 direction = Vector3.left;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction.normalized * moveSpeed;
    }
}
