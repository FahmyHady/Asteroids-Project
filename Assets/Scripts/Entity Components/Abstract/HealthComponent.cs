using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class HealthComponent : MonoBehaviour
{
    [field: SerializeField] public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }
    public bool Dead { get; private set; }
    public bool Invulnerable { get; set; }
    public IDieBehaviour DeathBehaviour { get; protected set; }
    public UnityAction OnHit;
    public UnityAction OnDeath;
    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }
    public bool GetHit(int damageToRecieve)
    {
        if (Dead) return true;
        OnHit?.Invoke();
        if (Invulnerable) return false;
        CurrentHealth -= damageToRecieve;
        if (CurrentHealth <= 0)
            Die();

        return Dead;
    }
    public void Reset()
    {
        CurrentHealth = MaxHealth;
        Dead = false;
    }
    void Die()
    {
        Dead = true;
        if (DeathBehaviour != null)
            DeathBehaviour.Die();
        OnDeath?.Invoke();
    }
}
