using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field: SerializeField] public Rigidbody2D myRB { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletPoolManager.ReturnBulletToPool(this);
    }

}
