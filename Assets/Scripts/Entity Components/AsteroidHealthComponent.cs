using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealthComponent : HealthComponent
{
    internal Asteroid myAsteroid;
    [field: SerializeField] public ParticleSystem DeathVFX { get; private set; }

    private void Start()
    {
        myAsteroid = GetComponent<Asteroid>();
        DeathBehaviour = new DefaultAsteroidDeathBehaviour(this, DeathVFX);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.gameObject.CompareTag("Asteroid"))
        {
            //Play VFX
        }
        else
        {
            GetHit(1);
        }
    }
}

