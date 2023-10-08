using UnityEngine;

public class SimpleJoystick : MonoBehaviour
{
    public static bool IsTouching { get; private set; } = false; // Flag to track if we are currently dragging.
    public static Vector2 DragDelta { get; private set; }
    private Vector2 touchStartPos; // The starting position of the mouse drag.
#if UNITY_EDITOR
    private void Update()
    {
        // Check for touch or mouse input.
        if (Input.GetMouseButtonDown(0))
        {
            // Store the initial touch/mouse position.
            touchStartPos = Input.mousePosition;
            IsTouching = true;
        }

        // While dragging...
        if (IsTouching)
        {
            // Calculate the difference between the current touch/mouse position and the initial position.
            DragDelta = (Vector2)Input.mousePosition - touchStartPos;

            // Normalize the delta to ensure consistent movement speed in all directions.
            DragDelta = DragDelta.normalized;

        }

        // When the touch/mouse is released, stop dragging.
        if (Input.GetMouseButtonUp(0))
        {
            DragDelta = Vector2.zero;
            IsTouching = false;
        }
    }
#else

    Touch touch;
    private void Update()
    {
        // Check for touch or mouse input.
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(!IsTouching)
            {
                IsTouching = true;
                touchStartPos = touch.position;
            }
            DragDelta = (touch.position - touchStartPos).normalized;
        }
        else
        {
            DragDelta = Vector2.zero;
            IsTouching = false;
        }
    }

#endif



}
