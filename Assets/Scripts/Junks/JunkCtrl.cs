using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : OOPMono
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get { return junkSpawner; } }
    
    [SerializeField] protected JunkSpawnPoints spawnPoints;
    public JunkSpawnPoints JunkSpawnPoints { get { return spawnPoints; } }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadJunkSpawnPoints();
    }
    protected virtual void LoadJunkSpawner()
    {
        if (junkSpawner != null) return;
        this.junkSpawner = this.transform.GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadJunkSpawnPoints()
    {
        if (spawnPoints != null) return;
        this.spawnPoints = Transform.FindObjectOfType<JunkSpawnPoints>();
        Debug.Log(transform.name + ": LoadJunkSpawnPoints", gameObject);
    }
}
