using UnityEngine;

public class DefaultAsteroidMovementBehaviour : IMovementBehaviour
{
    Rigidbody2D myRB;

    public DefaultAsteroidMovementBehaviour(Rigidbody2D myRB)
    {
        this.myRB = myRB;
    }

    public void Move(Vector2 movementDirection, float acceleration, float maxSpeed)
    {
        myRB.AddForce(movementDirection * maxSpeed, ForceMode2D.Impulse);
    }
}