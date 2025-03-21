using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    protected override void DespawnObject()
    {
        JunkSpawner.Instance.Despawn(transform);
    }
}
