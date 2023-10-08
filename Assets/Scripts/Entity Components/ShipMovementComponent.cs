using Unity.VisualScripting;
using UnityEngine;

public class ShipMovementComponent : MovementComponent
{
    [SerializeField] float acceleration;
    private void Awake()
    {
        Input.multiTouchEnabled = false;
        movementBehaviour = new DefaultShipMovementBehaviour(myRB);
    }

    private void FixedUpdate()
    {
        if (SimpleJoystick.IsTouching)
        {
            movementBehaviour.Move(SimpleJoystick.DragDelta, acceleration * Time.fixedDeltaTime, movementSpeed);
        }

    }
}
