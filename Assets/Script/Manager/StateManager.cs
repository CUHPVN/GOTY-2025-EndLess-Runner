using UnityEngine;

public class StateManager : MonoBehaviour
{
	public static StateManager Instance { get; private set; }
	public enum States { JumpState, FlyState, ZiczacState, Spider, Dead};
	public States CurrentStates;
	
	GameObject Player;
	private void Awake()
	{
		Instance = this;
	}
	private void Start()
	{
		Time.timeScale = 1f;
		CurrentStates = States.JumpState;
		Player = GameObject.FindGameObjectWithTag("Player");
		
	}

	public States GetState()
	{
		return CurrentStates;
	}

	public void ChangeState(States NewState)
	{
		if(NewState != States.Dead)
		{
			Player.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		Player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
		CurrentStates = NewState;
	}
}
