using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGun : Weapon
{
    public GameObject muzzle1;
    private void Update()
    {
        if (_isShooting) 
        {
            _timer -= Time.deltaTime;
        }
        if (_timer <= 0.0f) 
        {
            _timer = 1.0f;
            Shoot();
            _isShooting = false;
        }
    }
    public override void Shoot()
    {
        _isShooting = true;
        Bullet instance1 = Instantiate(bulletPrefab, new Vector3(muzzle1.transform.position.x, muzzle1.transform.position.y, muzzle1.transform.position.z), new Quaternion());
        Bullet instance2 = Instantiate(bulletPrefab, new Vector3(muzzle.transform.position.x, muzzle.transform.position.y, muzzle.transform.position.z), new Quaternion());
        instance1.transform.rotation = muzzle.transform.rotation;
        instance2.transform.rotation = muzzle.transform.rotation;
        instance2.damage = this.damage;
    }
    private float _timer = 1.0f;
    private bool _isShooting;
}
