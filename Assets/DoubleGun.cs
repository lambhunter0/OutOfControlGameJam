using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGun : Weapon
{
    public GameObject muzzle2;

    private void Update()
    {
        if (_isShooting)
        {
            _secondTimer -= Time.deltaTime;
        }
        if (_secondTimer <= 0.0f)
        {
            _secondTimer = 1.0f;
            Shoot();
            _isShooting = false;
        }
    }

    public override void Shoot()
    {
        _isShooting = true;
        Bullet instance1 = Instantiate(bulletPrefab, new Vector3(muzzle1.transform.position.x, muzzle1.transform.position.y, muzzle1.transform.position.z), new Quaternion());
        Bullet instance2 = Instantiate(bulletPrefab, new Vector3(muzzle2.transform.position.x, muzzle2.transform.position.y, muzzle2.transform.position.z), new Quaternion());
        
        instance1.transform.rotation = muzzle1.transform.rotation;
        instance2.transform.rotation = muzzle2.transform.rotation;
        
        instance1.damage = this.damage;
        instance2.damage = this.damage;
    }

    private float _secondTimer = 1.0f;
    private bool _isShooting;
}
