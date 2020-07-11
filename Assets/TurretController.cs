using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // shoots out raycasts? cone?
    //state 0: idle
    //  canon just rotates. if sees player, go to next
    //state 1, 2, 3: aiming -
    //if sees player, starts transitioning and tracking. if not, stay at last known position of player and then rotate
    //state 4: shooting
    //shoot, then timer
    //state 5: reloading
    //timer and track (if not see jsut rotate canon)




    public GameObject target;
    public GameObject anchor;
    public GameObject weapon;
    public float aimSpeed;
    //canseeplayer bool for sure
    void Start()
    {
        aimSpeed = 4.0f;
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            Aim();
        }
        else
        {
            //do nothing for now
            Debug.Log("no hit");
        };
    }

    private bool CanSeePlayer()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Enemies");
        layerMask = ~layerMask;
        Debug.DrawLine(weapon.transform.position, target.transform.position, Color.white, 0.1f);//s e c dur
        RaycastHit2D hit = Physics2D.Linecast(weapon.transform.position, target.transform.position, layerMask);
        return (hit.collider.gameObject.layer == 9);
    }

    private void Aim()
    {
        Vector2 direction = target.transform.position - anchor.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90.0f, Vector3.forward);
        weapon.transform.rotation = Quaternion.Slerp(weapon.transform.rotation, rotation, aimSpeed * Time.deltaTime);
    }
}
