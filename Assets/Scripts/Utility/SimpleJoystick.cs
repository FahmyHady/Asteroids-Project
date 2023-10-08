using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SimpleJoystick : MonoBehaviour
{
    private Vector2 touchStartPos; // The starting position of the touch/mouse drag.
    public static bool IsTouching { get; private set; } = false; // Flag to track if we are currently dragging.
    public static Vector2 DragDelta { get; private set; }
    Touch touch;
    private void Update()
    {
        // Check for touch or mouse input.
        if (Input.GetMouseButtonDown(0))
        {
            // Store the initial touch/mouse position.
#if UNITY_EDITOR
            touchStartPos = Input.mousePosition;
#else
             touch = Input.GetTouch(0);
            touchStartPos= touch.position;
#endif
            IsTouching = true;
        }

        // While dragging...
        if (IsTouching)
        {
            // Calculate the difference between the current touch/mouse position and the initial position.
#if UNITY_EDITOR
            DragDelta = (Vector2)Input.mousePosition - touchStartPos;
#else
            DragDelta = touch.deltaPosition;
#endif

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
}
