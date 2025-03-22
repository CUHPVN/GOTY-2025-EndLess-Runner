using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFly : MonoBehaviour
{
    [SerializeField] public float movespeed = 1f;
    [SerializeField] protected Vector3 direction = -Vector3.forward;

    protected void Awake()
    {
    }
    private void FixedUpdate()
    {
        movespeed = MapSpawner.Instance.GetBaseSpeed();
        transform.Translate(this.direction * this.movespeed * Time.deltaTime);
    }
}