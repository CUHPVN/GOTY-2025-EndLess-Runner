using System.Collections;
using UnityEngine;

#if UNITY_EDITOR
using Physics2D = Nomnom.RaycastVisualization.VisualPhysics2D;
#else
using Physics2D = UnityEngine.Physics2D;
#endif

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	bool IsGrounded;
	[SerializeField] Transform GroundCheck;
	[SerializeField] Transform SpiderTpCheck;
	[SerializeField] LayerMask GroundLayer;
	StateManager StM;

	[SerializeField] Transform GroundCollider;
	bool GroundCollided = false;

	[SerializeField] float JumpForce;
	[SerializeField] float FlyGravityScale;
	[SerializeField] float ZiczacForce;

	Vector2 TpLocation;
	[SerializeField] bool flipped = false;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		StM = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
	}

	void Update()
	{
		transform.position = new Vector3(-9f, transform.position.y, transform.position.z);
		GroundCollided = Physics2D.OverlapCapsule(GroundCollider.transform.position, new Vector2(0.12f, 0.32f), CapsuleDirection2D.Vertical, transform.rotation.eulerAngles.z, GroundLayer);
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
			case StateManager.States.SpiderState:
				Spider();
				break;
			case StateManager.States.DeadState:
				Dead();
				break;
			default:
				break;
		}
		if (GroundCollided)
		{
			StM.ChangeState(StateManager.States.DeadState);
			Debug.Log("Dead");
		}
	}
	private void Move()
	{
		if (rb.linearVelocity.y < 0f)
		{
			rb.gravityScale = 1.5f;
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -15f));
		}
		else
		{
			rb.gravityScale = 1f;
		}
		IsGrounded = Physics2D.OverlapCapsule(GroundCheck.transform.position, new Vector2(0.75f, 0.2f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
		if ((Input.GetButton("Jump")|| Input.GetMouseButton(0)) && IsGrounded)
		{
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
		}
		else if(Input.GetButtonUp("Jump") || Input.GetMouseButtonUp(0))
		{
			if(rb.linearVelocityY > 0)
			{
				
				rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY * 0.2f);
			}
		}
	}
	private void Fly()
	{
		rb.gravityScale = FlyGravityScale;
		if (rb.linearVelocityY > 15f)
		{
			rb.linearVelocityY = 15f;
		}
		else if (rb.linearVelocityY < -15f)
		{
			rb.linearVelocityY = -15f;
		}
		if (Input.GetButton("Jump") || Input.GetMouseButton(0))
		{
			rb.gravityScale = -FlyGravityScale;
		}
		else
		{
			rb.gravityScale = FlyGravityScale;
		}
	}

	private void Ziczac()
	{
		ZiczacForce = MapSpawner.Instance.GetBaseSpeed();
		rb.gravityScale = 0f;
		float temp = -1f;
		if (Input.GetButton("Jump") || Input.GetMouseButton(0))
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

	private void Spider()
	{

		Vector3 currentRotation = transform.rotation.eulerAngles;
		RaycastHit2D hit = Physics2D.BoxCast(SpiderTpCheck.transform.position, new Vector2(1f, 0.9f), 0f, SpiderTpCheck.transform.up, Mathf.Infinity, GroundLayer);
		if (hit)
		{
			TpLocation = hit.point;
		}
		else
		{
			TpLocation = transform.position;
		}
		if (rb.linearVelocity.y < 0f)
		{
			if (!flipped)
			{
				rb.gravityScale = 2f;
			}
			else
			{
				rb.gravityScale = -2f;
			}
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -15f));
		}
		else
		{
			if (!flipped)
			{
				rb.gravityScale = 1f;
			}
			else
			{
				rb.gravityScale = -1f;
			}
		}
		if (flipped)
		{
			transform.rotation = Quaternion.Euler(180f, 0f, 0f);
		}
		else if (!flipped)
		{
			transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		}
		IsGrounded = Physics2D.OverlapCapsule(GroundCheck.transform.position, new Vector2(0.75f, 0.2f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
		if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && IsGrounded && hit)
		{
			if(TpLocation.y >= 0)
			{
				transform.position = new Vector3(transform.position.x, TpLocation.y - 0.5f, transform.position.z);
			}
			else if(TpLocation.y <= 0)
			{
				transform.position = new Vector3(transform.position.x, TpLocation.y + 0.5f, transform.position.z);
			}
			flipped = !flipped;
			transform.rotation = Quaternion.Euler(currentRotation.x + 180f, currentRotation.y, currentRotation.z);
		}
	}
	private void Dead()
	{
		 // prototype thôi nên đổi
		// DeadState Logic, Làm ơn đừng cho người chơi revive vì tôi ko thích :)
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Trap"))
		{
			StM.ChangeState(StateManager.States.DeadState);
			Debug.Log("Dead");
		}
	}
}
