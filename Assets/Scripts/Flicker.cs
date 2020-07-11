using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer sr;
    public float flickerLength;
    void Start()
    {
        
    }

    
    void Update()
    {
        _currentFlickerTick -= Time.deltaTime;
        if (_currentFlickerTick <= 0.0f) 
        {
            _currentFlickerTick = flickerLength;
            SwapSprite();
        }
    }

    private void SwapSprite() 
    {
        if (sr.sprite == sprites[0])
        {
            sr.sprite = sprites[1];
        }
        else 
        {
            sr.sprite = sprites[0];
        }

    }
    private float _currentFlickerTick;
}
