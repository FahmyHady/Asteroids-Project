using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAsteroidDeathBehaviour : IDieBehaviour
{
    private AsteroidHealthComponent asteroidHealthComponent;
    private  ParticleSystem deathVFX;

    public DefaultAsteroidDeathBehaviour(AsteroidHealthComponent asteroidHealthComponent, ParticleSystem deathVFX)
    {
        this.asteroidHealthComponent = asteroidHealthComponent;
        this.deathVFX = deathVFX;
    }


    public void Die()
    {
        SimplifiedEventManager.AsteroidDeath.Invoke();
        GameObject.Instantiate(deathVFX, asteroidHealthComponent.transform.position, Quaternion.identity);
        int justDiedSize = (int)asteroidHealthComponent.myAsteroid.MySize;
        if (justDiedSize != 0)
        {
            AsteroidSize sizeToGet = (AsteroidSize)(justDiedSize - 1);
            for (int i = 0; i < 2; i++)
            {
                 AsteroidPoolManager.GetAsteroid(sizeToGet, asteroidHealthComponent.transform.position);
            }
        }
        asteroidHealthComponent.gameObject.SetActive(false);
        AsteroidPoolManager.ReturnAsteroidToPool(asteroidHealthComponent.myAsteroid);

    }

}
