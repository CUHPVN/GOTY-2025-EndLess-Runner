using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFly : OOPMono
{
    [SerializeField] public float movespeed = 1f;
    [SerializeField] protected Vector3 direction = -Vector3.forward;

    protected override void Awake()
    {
        movespeed = JunkRandom.Instance.GetBaseSpeed();
    }
    private void FixedUpdate()
    {
        movespeed = JunkRandom.Instance.GetBaseSpeed();
        transform.Translate(this.direction * this.movespeed * Time.deltaTime);
    }
}