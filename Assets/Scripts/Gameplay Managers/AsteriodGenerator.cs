using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteriodGenerator : MonoBehaviour
{
    [SerializeField] AnimationCurve asteriodMaxCountOverTimeInSeconds;
    public float ElapsedTime { get; private set; }
    float maxCount;
    float sizeChance;
    void Update()
    {
        ElapsedTime += Time.deltaTime;
        maxCount = asteriodMaxCountOverTimeInSeconds.Evaluate(ElapsedTime);
        //   sizeChance = asteroidChanceModifierOverTimeInSeconds.Evaluate(ElapsedTime);
        if (AsteroidPoolManager.ActiveAsteriodCount < maxCount)
        {

            AsteroidPoolManager.GetAsteroid((AsteroidSize)UnityEngine.Random.Range(0, Enum.GetValues(typeof(AsteroidSize)).Length), Utility.GetRandomOffScreenPoint());
        }

    }

}
