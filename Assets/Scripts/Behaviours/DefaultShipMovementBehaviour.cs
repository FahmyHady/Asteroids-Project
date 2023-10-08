using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultShipMovementBehaviour : IMovementBehaviour
{
    Rigidbody2D shipRigidbody;

    public DefaultShipMovementBehaviour(Rigidbody2D shipRigidbody)
    {
        this.shipRigidbody = shipRigidbody;
    }


    public void Move(Vector2 movementDirection, float acceleration, float maxSpeed)
    {
        if (shipRigidbody.velocity.sqrMagnitude < maxSpeed*maxSpeed)
            shipRigidbody.AddForce(movementDirection * acceleration);
        else
            shipRigidbody.velocity = movementDirection * maxSpeed;
        float targetRotation = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
        Utility.LerpPhysicsRotationOverTime(shipRigidbody, targetRotation, 0.25f);
    }
}