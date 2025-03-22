using UnityEngine;

public class Portal : MonoBehaviour
{
    StateManager StM;
    public StateManager.States ChangeStateTo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StM = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StM.ChangeState(ChangeStateTo);
        }
    }
}
