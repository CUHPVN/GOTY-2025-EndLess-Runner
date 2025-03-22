using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTraps : MonoBehaviour
{
    public GameObject Spawner;
    StateManager StM;
    public List<GameObject> JumpObstacle;
    public List<GameObject> FlyObstacle;
    List<GameObject> CurrentTrapList;
    bool Spawned = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StM = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (StM.GetState())
        {
            case StateManager.States.JumpState:
                SpawnJumpObstacle();
                break;
            case StateManager.States.FlyState:
                break;
            default:
                break;
        }
    }
    void SpawnJumpObstacle()
    {
        if (!Spawned)
        {

            StartCoroutine(SpawnRate());

        }

    }
    IEnumerator SpawnRate()
    {
        GameObject temp = Instantiate(JumpObstacle[Random.Range(0, JumpObstacle.Count - 1)], Spawner.transform.position, Quaternion.identity);
        Destroy(temp, 15f);
        Spawned = true;
        yield return new WaitForSeconds(2);
        Spawned = false;

    }


}
