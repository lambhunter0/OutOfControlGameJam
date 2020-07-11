using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Vector3 localScale;
    void Start()
    {
        localScale = transform.localScale;
    }

    public void TakeDamage(float health, float maxHealth) 
    {
        localScale.x = health / maxHealth;
        localScale.y = 0.04f;
        transform.localScale = localScale;
        Debug.Log("i am smol");

    }
}
