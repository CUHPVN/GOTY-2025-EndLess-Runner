using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum States { JumpState, FlyState };
    public States CurrentStates;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        CurrentStates = States.JumpState;
    }
}
