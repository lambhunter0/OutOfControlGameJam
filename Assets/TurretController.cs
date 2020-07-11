using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretController : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject target;
    public GameObject anchor;
    public Weapon weapon;
    public float aimSpeed;
    public Sprite[] sprites;
    //canseeplayer bool for sure
    void Start()
    {
        aimSpeed = 4.0f;
        _state = 0;
        _hasShot = false; 
    }

    void Update()
    {
        CountTick();
        if (_state == 5 && !_hasShot) 
        {
            _hasShot = true;
            weapon.Shoot();
        }
        if (_state == 0) 
        {
            _hasShot = false;
        }
        if (CanSeePlayer())
        {
            Aim();
        }
        else
        {
            //do nothing for now
            //Debug.Log("no hit");
        }
    }

    private void CountTick() 
    {
        _currentTick -= Time.deltaTime;
        if (_currentTick <= 0.0f) 
        {
            _currentTick = stateLength;
            _state = (_state == 5) ? 0 : _state + 1;
            UpdateSprite(_state);
        }
    }
    private float _currentTick;
    public float stateLength; //how long does each state last
    private bool _hasShot;
    private void UpdateSprite(int spriteIndex) 
    {
        sr.sprite = sprites[spriteIndex];
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
    private int _state;
}
