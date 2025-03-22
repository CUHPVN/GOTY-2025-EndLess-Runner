using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance { get; private set; }
    public enum States { JumpState, FlyState, ZiczacState };
    public States CurrentStates;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        CurrentStates = States.JumpState;
    }

    public States GetState()
    {
        return CurrentStates;
    }

    public void ChangeState(States NewState)
    {
        CurrentStates = NewState;
    }
}
