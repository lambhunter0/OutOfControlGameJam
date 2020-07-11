using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public GameObject muzzle1;

    public Bullet bulletPrefab;

    public virtual void Shoot()
    {
        Bullet instance = Instantiate(bulletPrefab, new Vector3(muzzle1.transform.position.x, muzzle1.transform.position.y, muzzle1.transform.position.z) ,new Quaternion());
        instance.transform.rotation = muzzle1.transform.rotation;
        instance.damage = this.damage;
    }
}
