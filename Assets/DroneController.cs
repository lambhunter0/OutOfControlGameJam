using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : Enemy
{
    [SerializeField] protected Vector3 direction;
    [SerializeField] protected float span;
    private Vector3 pos1;
    private Vector3 pos2;

    protected override void Start()
    {
        base.Start();

        pos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (direction == Vector3.right)
        {
            pos2 = new Vector3(pos1.x + span, pos1.y, pos1.z);
        }
        else if (direction == Vector3.left)
        {
            pos2 = new Vector3(pos1.x - span, pos1.y, pos1.z);
        }
        else if (direction == Vector3.up)
        {
            pos2 = new Vector3(pos1.x, pos1.y + span, pos1.z);
        }
        else if (direction == Vector3.down)
        {
            pos2 = new Vector3(pos1.x, pos1.y - span, pos1.z);
        }

        Debug.Log("Drone pos1 = " + pos1);
        Debug.Log("Drone pos2 = " + pos2);
    }

    protected override void Update()
    {
        base.Update();

        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
