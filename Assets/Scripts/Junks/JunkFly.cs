using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ObjectFly
{
    [SerializeField] private Transform spawnPos;
    private bool isSpawn = false;
    protected override void ResetValue()
    {
        base.ResetValue();
        isSpawn = false;
        movespeed = JunkRandom.Instance.GetBaseSpeed();

    }
    
    private void FixedUpdate()
    {
        movespeed = JunkRandom.Instance.GetBaseSpeed();
        transform.Translate(this.direction * this.movespeed * Time.deltaTime);
        if (!isSpawn&&Vector3.Distance(spawnPos.position,transform.position)>=20)
        {
            isSpawn = true;
            JunkRandom.Instance.JunkSpawningWithPos(transform.position+new Vector3(0,0,20f));
        }
    }

    protected virtual void OnEnable()
    {
        //this.GetFlyDirection();
        ResetValue();
    }
        
    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameCtrl.Instance.Player.transform.position;
        Vector3 objPos = transform.parent.position;
        camPos.x += Random.Range(-10,10);
        camPos.y += Random.Range(-10,10);

        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.parent.rotation = Quaternion.Euler( 0f, 0f, rot_z);

        Debug.DrawLine(objPos, objPos + diff * 7, Color.red, Mathf.Infinity);

    }
}