using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
	Animator anim;
	StateManager StM;
	Rigidbody2D rb;
	PlayerMovement PM;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		anim = GetComponent<Animator>();
		StM = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
		rb = GetComponent<Rigidbody2D>();
		PM = GetComponent<PlayerMovement>();
	}

	// Update is called once per frame
	void Update()
	{

		switch (StM.GetState())
		{
			case StateManager.States.JumpState:
				TPFalse();
				anim.SetFloat("VelocityY", rb.linearVelocityY);
				anim.SetBool("IsJump", !PM.IsGrounded);
				break;
			case StateManager.States.FlyState:
				TPFalse();
				break;
			case StateManager.States.ZiczacState:
				TPFalse();
				break;
			case StateManager.States.SpiderState:
				if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
				{
					anim.SetBool("TP", true);
				}
				break;
			case StateManager.States.DeadState:
				//Dead();
				break;
			default:
				break;
		}
		anim.SetInteger("States", (int)StM.GetState());
	}

	public void TPFalse()
	{
		anim.SetBool("TP", false);
	}
}
