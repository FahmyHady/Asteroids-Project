using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthComponent : HealthComponent
{
    [field: SerializeField] public int NumberOfLives { get; set; }
    [field: SerializeField] public float InvulnerabilityDurationOnDeath { get; private set; }
    [field: SerializeField] public Rigidbody2D ShipRB { get; private set; }
    [field: SerializeField] public GameObject Ship3DModel { get; private set; }
    [field: SerializeField] public ParticleSystem DeathVFX { get; private set; }
    [field: SerializeField] public Collider2D[] PhysicsColliders { get; private set; }
    
    private void Start()
    {
        DeathBehaviour = new DefaultShipDeathBehaviour(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetHit(1);
    }
}
