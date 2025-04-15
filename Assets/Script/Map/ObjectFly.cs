using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ObjectFly : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Vector3 direction = -Vector3.forward;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveSpeed = MapSpawner.Instance.GetBaseSpeed();
        rb.linearVelocity = direction.normalized * moveSpeed;
    }
}