using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : MonoBehaviour
{
    private void Update()
    {
        transform.parent.rotation = transform.rotation;
    }
}
