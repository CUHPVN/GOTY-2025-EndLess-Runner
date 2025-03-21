using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : OOPMono
{
    private static JunkRandom instance;
    public static JunkRandom Instance => instance;

    [SerializeField] private JunkCtrl junkCtrl;
    private float basePosition = 0f;
    [SerializeField] private float baseSpeed = 10f;
    private float baseTimeSpawn => Mathf.Max(0.01f, 20f / baseSpeed);

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Debug.LogError("Only one instance of JunkRandom is allowed.");
            return;
        }
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    private void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;
        junkCtrl = GetComponent<JunkCtrl>();
        Debug.Log($"{transform.name}: JunkCtrl loaded.", gameObject);
    }

    protected override void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            BaseSpawning();
        }
        JunkSpawning();
    }

    private void FixedUpdate()
    {
 
    }
    public float GetBaseSpeed()
    {
        return baseSpeed;
    }
    public void JunkSpawning()
    {
        if (junkCtrl?.JunkSpawnPoints == null || junkCtrl.JunkSpawner == null) return;

        Transform randomPosition = junkCtrl.JunkSpawnPoints.GetRandom();
        if (randomPosition == null) return;

        Transform spawnedJunk = junkCtrl.JunkSpawner.Spawn(JunkSpawner.pad, randomPosition.position, transform.rotation);
        if (spawnedJunk != null)
            spawnedJunk.gameObject.SetActive(true);
    }
    public void JunkSpawningWithPos(Vector3 pos)
    {
        if (junkCtrl?.JunkSpawnPoints == null || junkCtrl.JunkSpawner == null) return;
        Transform spawnedJunk = junkCtrl.JunkSpawner.Spawn(JunkSpawner.pad, pos, transform.rotation);
        if (spawnedJunk != null)
            spawnedJunk.gameObject.SetActive(true);
    }

    private void BaseSpawning()
    {
        if (junkCtrl?.JunkSpawner == null) return;

        Vector3 spawnPosition = new Vector3(0, 0, basePosition);
        Transform spawnedBase = junkCtrl.JunkSpawner.Spawn(JunkSpawner.pad, spawnPosition, transform.rotation);
        if (spawnedBase != null)
            spawnedBase.gameObject.SetActive(true);

        basePosition += 20f;
    }
}
