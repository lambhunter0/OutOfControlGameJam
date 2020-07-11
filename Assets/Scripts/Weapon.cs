using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public GameObject muzzle;

    public Bullet bulletPrefab;
    public virtual void Shoot()
    {
        Bullet instance = Instantiate(bulletPrefab, new Vector3(muzzle.transform.position.x, muzzle.transform.position.y, muzzle.transform.position.z) ,new Quaternion());
        instance.transform.rotation = muzzle.transform.rotation;
        instance.damage = this.damage;
    }
}
