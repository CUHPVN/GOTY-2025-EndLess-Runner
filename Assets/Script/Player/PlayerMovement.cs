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
	public bool IsGrounded;
	[SerializeField] Transform GroundCheck;
	[SerializeField] Transform SpiderTpCheck;
	[SerializeField] LayerMask GroundLayer;
	[SerializeField] LayerMask KGroundLayer;
	[SerializeField] LayerMask Collectable;
	StateManager StM;

	[SerializeField] Transform GroundCollider;
	bool GroundCollided = false;

	[SerializeField] float JumpForce;
	[SerializeField] float FlyGravityScale;
	[SerializeField] float ZiczacForce;

	public bool InTutorial;
	Vector2 TpLocation;
	[SerializeField] bool flipped = false;
	public GameObject ParSys;
	ParticleSystem PSys;
	public GameObject ParSys2;
	ParticleSystem PSys2;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		StM = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
		PSys = ParSys.GetComponent<ParticleSystem>();
		PSys2 = ParSys2.GetComponent<ParticleSystem>();
	}

	void Update()
	{
		transform.position = new Vector3(-9f, transform.position.y, transform.position.z);
		GroundCollided = Physics2D.OverlapCapsule(GroundCollider.transform.position, new Vector2(0.12f, 0.32f), CapsuleDirection2D.Vertical, transform.rotation.eulerAngles.z, KGroundLayer);
		if(StM.GetState() != StateManager.States.JumpState && PSys2.isEmitting)
		{
			PSys2.Stop();
		}
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
			if(PowerUp.Instance.ShieldActive)
			{
				MapSpawner.Instance.SetBase();
				PowerUp.Instance.BreakShieldPowerUp();
				//TODO: biến tất cả map hiện tại thành base hoặc cho bất tử trong 1 khoảng thời gian, Phúc xử lí phần này đi :)
				//Debug.Log("biến tất cả map hiện tại thành base hoặc cho bất tử trong 1 khoảng thời gian, Phúc xử lí phần này đi :)");
			}
			else
			{	
				StM.ChangeState(StateManager.States.DeadState);
				//Debug.Log("Dead");
			}
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
		IsGrounded = Physics2D.OverlapCapsule(GroundCheck.transform.position, new Vector2(1f, 0.2f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
		if(IsGrounded && !PSys2.isEmitting)
		{
			PSys2.Play();
		}
		else if(!IsGrounded && PSys2.isEmitting)
		{
			PSys2.Stop();
		}
		if (InputManager.IsTouching() && IsGrounded)
		{
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
		}
		else if(InputManager.TouchEnded())
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
		if (InputManager.IsTouching())
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
		if(!InTutorial)
		{
			ZiczacForce = MapSpawner.Instance.GetBaseSpeed();
		}
		else
		{
			ZiczacForce = 7f;
		}
		rb.gravityScale = 0f;
		float temp = -1f;
		if (InputManager.IsTouching())
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
		RaycastHit2D hit = Physics2D.BoxCast(SpiderTpCheck.transform.position, new Vector2(1f, 0.9f), 0f, SpiderTpCheck.transform.up, Mathf.Infinity, KGroundLayer);
		RaycastHit2D[] hitCollect = Physics2D.BoxCastAll(SpiderTpCheck.transform.position, new Vector2(1f, 0.9f), 0f, SpiderTpCheck.transform.up, 56.25f, Collectable);
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
		if (InputManager.TouchBegan() && IsGrounded && hit)
		{
			if(hitCollect != null)
			{
				foreach(RaycastHit2D Collect in hitCollect)
				{
					if(Collect.collider.gameObject.CompareTag("Coin"))
					{
						Collect.collider.gameObject.GetComponent<Coin>().EatCoin();
					}
					else
					{
						Collect.collider.gameObject.SendMessage("OnTriggerEnter2D",GetComponent<Collider2D>());
					}
				}
			}
			if(!flipped)
			{
				transform.position = new Vector3(transform.position.x, TpLocation.y - 0.5f, transform.position.z);
			}
			else if(flipped)
			{
				transform.position = new Vector3(transform.position.x, TpLocation.y + 0.5f, transform.position.z);
			}
			flipped = !flipped;
			transform.rotation = Quaternion.Euler(currentRotation.x + 180f, currentRotation.y, currentRotation.z);
			PSys.Play();
			
		}
	}
	private void Dead()
	{
		PowerUp.Instance.CurrentX2CoinDuration = 0f;
		PowerUp.Instance.CurrentShieldDuration = 0f;
		PowerUp.Instance.CurrentX2ScoreDuration = 0f;
		
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Trap"))
		{
			if(PowerUp.Instance.ShieldActive)
			{
				MapSpawner.Instance.SetBase();
				PowerUp.Instance.BreakShieldPowerUp();
				//TODO: biến tất cả map hiện tại thành base hoặc cho bất tử trong 1 khoảng thời gian, Phúc xử lí phần này đi :)
				//Debug.Log("biến tất cả map hiện tại thành base hoặc cho bất tử trong 1 khoảng thời gian, Phúc xử lí phần này đi :)");
			}
			else
			{	
				StM.ChangeState(StateManager.States.DeadState);
				//Debug.Log("Dead");
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Coin"))
		{
			collision.gameObject.GetComponent<Coin>().EatCoin();
		}
	}
}
