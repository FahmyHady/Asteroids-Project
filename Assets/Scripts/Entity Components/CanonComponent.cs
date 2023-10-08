using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonComponent : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] float bulletSpeed;
    [SerializeField] float myBulletLife = 2;
    [SerializeField] float fireInterval = 2.0f; // Time between each firing in seconds.
    float lockedUntil;
    private void Update()
    {
        if (SimpleJoystick.IsTouching)
        {
            if (Time.time > lockedUntil)
            {
                BulletPoolManager.GetBullet(muzzle.right * bulletSpeed, myBulletLife, muzzle.position);
                lockedUntil = Time.time + fireInterval;
            }
        }
    }

}
