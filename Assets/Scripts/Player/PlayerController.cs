﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Weapon weapon;
    public Slider healthbar;
    private void Start()
    { 
        zero = new Quaternion(0,0,0,0);
        _CanShoot = true;
        _currentTick = shootSpeed;
        _health = _maxHealth = 100.0f;
    }
    void Update()
    {
        PlayerInput();
        CountTick();
        ClampRotation();
        if (_health <= 0.0f) 
        {

            Debug.Log("ded");
        }
    }

    private void PlayerInput() 
    {
        if (Input.GetKey(KeyCode.UpArrow)) 
        { 
            rb.AddForce(transform.up * moveSpeed *Time.deltaTime);
            _target = transform.up;
        }
        if (Input.GetKey(KeyCode.DownArrow)) 
        { 
            rb.AddForce(transform.up * -1 * moveSpeed * Time.deltaTime);
            _target = -transform.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) 
        { 
            rb.AddForce(transform.right * -1 * moveSpeed * Time.deltaTime);
            _target = -transform.right;
        }
        if (Input.GetKey(KeyCode.RightArrow)) 
        { 
            rb.AddForce(transform.right * moveSpeed * Time.deltaTime);
            _target = transform.right;
        }
        if (Input.GetKey(KeyCode.Space)) 
        { 
            TryShoot(); 
        }
    }

    private void ClampRotation() 
    {
        transform.rotation = zero;
    }

    private void TryShoot() 
    {
        if (_CanShoot)
        {
            Debug.Log("BANG");
            _CanShoot = false;
            _currentTick = shootSpeed;
        }
    }

    private void CountTick() 
    {
        if (!_CanShoot) 
        {
            _currentTick -= Time.deltaTime;
        }
        if (_currentTick <= 0.0f) 
        {
            _CanShoot = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 10)
        {
            Bullet b = collision.collider.gameObject.GetComponent<Bullet>();
            if (b != null)
            {
                _health -= (float)b.damage;
                healthbar.value = _health / _maxHealth;
                Debug.Log(_health + "/" + _maxHealth);
                b.Die();
            }
        }
    }

    private float _health;
    private float _maxHealth;
    private float _currentTick;
    private bool _CanShoot;
    public float shootSpeed;//interval between shots if hold down spacebar in seconds
    private Vector2 _target;
    private Quaternion zero;
}
