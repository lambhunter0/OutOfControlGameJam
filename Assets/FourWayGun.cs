using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayGun : Weapon
{
    public GameObject muzzle2;
    public GameObject muzzle3;
    public GameObject muzzle4;

    public override void Shoot()
    {
        Bullet instance1 = Instantiate(bulletPrefab, new Vector3(muzzle1.transform.position.x, muzzle1.transform.position.y, muzzle1.transform.position.z), new Quaternion());
        Bullet instance2 = Instantiate(bulletPrefab, new Vector3(muzzle2.transform.position.x, muzzle2.transform.position.y, muzzle2.transform.position.z), new Quaternion());
        Bullet instance3 = Instantiate(bulletPrefab, new Vector3(muzzle3.transform.position.x, muzzle3.transform.position.y, muzzle3.transform.position.z), new Quaternion());
        Bullet instance4 = Instantiate(bulletPrefab, new Vector3(muzzle4.transform.position.x, muzzle4.transform.position.y, muzzle4.transform.position.z), new Quaternion());

        instance1.transform.rotation = muzzle1.transform.rotation;
        instance2.transform.rotation = muzzle2.transform.rotation;
        instance3.transform.rotation = muzzle3.transform.rotation;
        instance4.transform.rotation = muzzle4.transform.rotation;

        instance1.moveSpeed = 600;
        instance2.moveSpeed = 600;
        instance3.moveSpeed = 600;
        instance4.moveSpeed = 600;

        instance1.damage = this.damage;
        instance2.damage = this.damage;
        instance3.damage = this.damage;
        instance4.damage = this.damage;
    }
}
