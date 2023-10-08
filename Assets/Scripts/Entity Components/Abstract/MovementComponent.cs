using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MovementComponent : MonoBehaviour
{
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected Rigidbody2D myRB;
    public IMovementBehaviour movementBehaviour;
}
