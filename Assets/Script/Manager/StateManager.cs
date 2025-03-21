using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum States {JumpState,FlyState};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        States CurrentState;
        CurrentState = States.JumpState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
