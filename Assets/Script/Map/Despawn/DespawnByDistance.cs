using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 40f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Camera maincamera;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected override void Despawning()
    {
        if (!this.CanDespawn()) return;
        if(transform.GetComponent<Pad>() != null)
        {
            MapSpawner.Instance.RemovePad(transform);
        }
        SpawnManager.Instance.Despawn(transform);
    }

    protected virtual void LoadCamera()
    {
        if (this.maincamera != null) return;
        this.maincamera = Transform.FindAnyObjectByType<Camera>();
        Debug.Log(transform.parent.name + ": Load Camera", gameObject);
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.maincamera.transform.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }

}
