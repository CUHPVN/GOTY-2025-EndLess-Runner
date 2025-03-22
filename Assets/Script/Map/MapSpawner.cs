using NUnit.Framework;
using System;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public static MapSpawner Instance {  get; private set; }
    [SerializeField] private float speed=2f;
    [SerializeField] private string padName="PadJump_1";
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
        Transform pad = SpawnManager.Instance.Spawn(this.padName, pos.x, pos.y, Quaternion.identity);
        if (pad != null)
            pad.gameObject.SetActive(true);
    }
    public float GetBaseSpeed()
    {
        return speed;
    }
}
