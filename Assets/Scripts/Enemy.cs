using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    public HealthBar healthbar;

    [SerializeField] protected float speed;

    public GameObject anchor;
    public GameObject target;
    public Weapon weapon;
    public float aimSpeed;

    [SerializeField] protected SpriteRenderer sr;
    [SerializeField] protected Sprite[] sprites;

    [SerializeField] protected float stateLength; //how long does each state last
    protected float _maxHealth;

    [SerializeField] protected bool aims = true;

    protected virtual void Start()
    {
        _maxHealth = health;
        healthbar.gameObject.SetActive(false);

        _state = 0;
        _hasShot = false;
    }

    protected virtual void Update()
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

        if (aims && CanSeePlayer())
        {
            Aim();
        }
        else
        {
            //do nothing for now
            //Debug.Log("no hit");
        }
    }

    public void TakeDamage(float damage) 
    {
        health -= damage;
        Debug.Log(health + "/" + _maxHealth + " enemy");

        if (health < _maxHealth) 
        {
            healthbar.gameObject.SetActive(true);
            healthbar.TakeDamage(health, _maxHealth);
        }
        if (health <= 0.0f) 
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 9 || collision.collider.gameObject.layer == 10) 
        {
            Bullet b = collision.collider.gameObject.GetComponent<Bullet>();
            if (b != null)
            {
                TakeDamage(b.damage);
                Debug.Log("ouch");
                b.Die();
            }
        }
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
    private void UpdateSprite(int spriteIndex)
    {
        sr.sprite = sprites[spriteIndex];
    }

    public void Die() 
    {
        float i = UnityEngine.Random.Range(0.0f, 1.0f);
        if (i > 0.49f) 
        { 
            //spawn powerup
        }
        Destroy(this.gameObject);
    }
    private float _currentTick;
    private bool _hasShot;
    private int _state;
}
