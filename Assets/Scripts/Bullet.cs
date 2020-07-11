using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Vector3 direction;
    public int damage;
    private void Start()
    {
        
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.AddForce(transform.up * moveSpeed * Time.deltaTime);
    }

    public void Die() 
    {
        Destroy(this.gameObject);
    }
}
