using UnityEngine;
public interface IMovementBehaviour
{
    public void Move(Vector2 movementDirection, float acceleration, float maxSpeed);
}
public interface IDieBehaviour
{
    public void Die();
}