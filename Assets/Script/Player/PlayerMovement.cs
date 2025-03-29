using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	bool IsGrounded;
	[SerializeField] Transform GroundCheck;
	[SerializeField] LayerMask GroundLayer;
	StateManager StM;

	[SerializeField] Transform GroundCollider;
	bool GroundCollided = false;

	[SerializeField] float JumpForce;
	[SerializeField] float FlyForce;
	[SerializeField] float ZiczacForce;




	bool isCrouch = false;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		StM = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
	}

	void Update()
	{
		GroundCollided = Physics2D.OverlapCapsule(GroundCollider.transform.position, new Vector2(0.12f, 0.42f), CapsuleDirection2D.Vertical, 0, GroundLayer);
		switch (StM.GetState())
		{
			case StateManager.States.JumpState:
				Move();
				break;
			case StateManager.States.FlyState:
				Fly();
				break;
			case StateManager.States.ZiczacState:
				Ziczac();
				break;
			default:
				break;
		}
		if (GroundCollided)
		{
			Debug.Log("Dead");
		}
	}
	private void Move()
	{
		if (rb.linearVelocity.y < 0f)
		{
			rb.gravityScale = 2f;
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -15f));
		}
		else
		{
			rb.gravityScale = 1f;
		}
		transform.rotation = Quaternion.Euler(0, 0, 0);
		IsGrounded = Physics2D.OverlapCapsule(GroundCheck.transform.position, new Vector2(0.75f, 0.2f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
		if (Input.GetKey(KeyCode.Space) && IsGrounded)
		{
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
		}
		if (Input.GetKey(KeyCode.DownArrow) && IsGrounded && !isCrouch)
		{
			isCrouch = true;
			StartCoroutine(Crouch());
		}
	}
	private void Fly()
	{
		transform.rotation = Quaternion.Euler(0, 0, 0);
		rb.gravityScale = 1f;
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

	private void Ziczac()
	{
		ZiczacForce = MapSpawner.Instance.GetBaseSpeed();
		rb.gravityScale = 0f;
		float temp = -1f;
		if (Input.GetKey(KeyCode.Space))
		{
			temp = 1f;
			transform.rotation = Quaternion.Euler(0, 0, 45f);
		}
		else
		{
			temp = -1f;
			transform.rotation = Quaternion.Euler(0, 0, -45f);
		}
		rb.linearVelocity = new Vector2(ZiczacForce, ZiczacForce * temp);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Trap"))
		{
			Debug.Log("Dead");
		}
	}
	IEnumerator Crouch()
	{
		rb.linearVelocityY = -30;
		transform.localScale = new Vector3(1f, 0.5f, 1f);
		yield return new WaitForSeconds(1f);
		transform.localScale = new Vector3(1f, 1f, 1f);
		isCrouch = false;
	}
}
