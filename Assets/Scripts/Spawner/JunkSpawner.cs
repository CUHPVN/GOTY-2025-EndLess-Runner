using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    protected static JunkSpawner instance;
    public static JunkSpawner Instance { get { return instance; } }

     

    public static string pad = "Pad_1";

     
    
    protected void Update()
    {
        int ran = UnityEngine.Random.Range(0, this.prefabs.Count);
        
        pad = this.prefabs[ran].name;
    }    
    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null) Debug.LogError("Only 1 Pad allow to exit");
        JunkSpawner.instance = this;
    }
}
    