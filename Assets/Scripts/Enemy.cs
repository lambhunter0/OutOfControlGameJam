using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    public HealthBar healthbar;

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
            Destroy(this.gameObject);
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

    public float _maxHealth;

}
