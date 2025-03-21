using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    protected static BulletSpawner instance;
    public static BulletSpawner Instance { get { return instance; } }

    public static string bulletOne = "Bullet1";
    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exit");
        BulletSpawner.instance = this;
    }
}
