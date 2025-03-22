using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public static MapSpawner Instance {  get; private set; }
    [SerializeField] private float speed=2f;
    [SerializeField] private List<Transform> jumpStatePrefabs = new List<Transform>();
    [SerializeField] private List<Transform> flyStatePrefabs = new List<Transform>();
    [SerializeField] private List<Transform> ziczacStatePrefabs = new List<Transform>();
    private string padName;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SpawningWithPos(Vector2.zero);
    }

    void Update()
    {
        
    }
    public void SpawningWithPos(Vector3 pos)
    {
        StateManager.States state = StateManager.Instance.GetState();
        switch (state){
            case StateManager.States.JumpState:
                padName = jumpStatePrefabs[UnityEngine.Random.Range(0, jumpStatePrefabs.Count)].name;
                break;
            case StateManager.States.FlyState:
                padName = flyStatePrefabs[UnityEngine.Random.Range(0, flyStatePrefabs.Count)].name;
                break;
            default:
                padName = jumpStatePrefabs[UnityEngine.Random.Range(0, jumpStatePrefabs.Count)].name;
                break;
        }
        Transform pad = SpawnManager.Instance.Spawn(this.padName, pos.x, pos.y, Quaternion.identity);
        if (pad != null)
            pad.gameObject.SetActive(true);
    }
    public float GetBaseSpeed()
    {
        return speed;
    }
}
