using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class DespawnByTime : Despawn

{
   
    [SerializeField] protected float timeLimit = 1f;
    [SerializeField] public float ontime = 0f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected override void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }

    protected override bool CanDespawn()
    {
        this.ontime = this.ontime + Time.deltaTime;
        if (this.ontime > this.timeLimit) return true;
        return false;
    }

}
