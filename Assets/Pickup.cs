using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string type;
    public float value;
    public SpriteRenderer sr;
    public void SetInfo(string s, float v, Sprite spr) 
    {
        type = s;
        value = v;
        sr.sprite = spr;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) 
        {
            PlayerController p = collision.gameObject.GetComponent<PlayerController>();
            if (p != null) 
            {
                //give player the powerup
                p.ReceivePowerUp(type, value);
                Destroy(this.gameObject);
            }
        }
    }
}
