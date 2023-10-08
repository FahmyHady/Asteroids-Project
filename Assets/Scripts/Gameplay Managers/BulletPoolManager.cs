using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : Singleton<BulletPoolManager>
{
    [SerializeField] Bullet bulletPrefab;
    ObjectPool<Bullet> bulletPool;
    protected override void Awake()
    {
        base.Awake();
        bulletPool = new ObjectPool<Bullet>(bulletPrefab, transform, 10);
    }

    public static Bullet GetBullet(Vector2 bulletSpeed, float bulletLifeTime, Vector3 pos)
    {
        var bullet = Instance.bulletPool.GetObjectFromPool();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = pos;
        bullet.transform.right = bulletSpeed.normalized;
        bullet.myRB.velocity = bulletSpeed;
        bullet.StartCoroutine(Utility.DoAfterDelay(bulletLifeTime, () => ReturnBulletToPool(bullet)));
        return bullet;
    }
    public static void ReturnBulletToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.myRB.velocity = Vector3.zero;
        Instance.bulletPool.ReturnObjectToPool(bullet);
    }
}
