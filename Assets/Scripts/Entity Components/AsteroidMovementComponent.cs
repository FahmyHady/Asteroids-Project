using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovementComponent : MovementComponent
{
    private void Awake()
    {
        movementBehaviour = new DefaultAsteroidMovementBehaviour(myRB);
    }

    private void OnEnable()
    {
        //Get the percentage of current size compared to max size
        //Since min size is 2, we're getting some speed because we're comparing from 0 to 16, 2 would give us 12.5%
        float sizePercentageFromMaxSize = Mathf.InverseLerp(0, 16, transform.localScale.x);


        //Use the inverse so that smaller asteroids get higher speeds
        float inverseThePercentage = 1 / sizePercentageFromMaxSize;                      
        var speedToUse = movementSpeed * inverseThePercentage;
        movementBehaviour.Move(Random.onUnitSphere, speedToUse, speedToUse);
    }
}

