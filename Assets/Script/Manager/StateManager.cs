using UnityEngine;

public class StateManager : MonoBehaviour
{
	public static StateManager Instance { get; private set; }
	public enum States { JumpState, FlyState, ZiczacState };
	public States CurrentStates;
	
	GameObject Player;
	private void Awake()
	{
		Instance = this;
	}
	private void Start()
	{
		CurrentStates = States.JumpState;
		Player = GameObject.FindGameObjectWithTag("Player");
		
	}

	public States GetState()
	{
		return CurrentStates;
	}

	public void ChangeState(States NewState)
	{
		Player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
		CurrentStates = NewState;
	}
}
