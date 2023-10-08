using UnityEngine;

public class RotationPingPong : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // Axis to rotate around.
    public float rotationAmount = 30.0f; // Amount to rotate by.
    public float pingPongSpeed = 1.0f; // Speed of the ping-pong motion.

    private float initialRotation;
    private float pingPongDirection = 1.0f;

    private void Start()
    {
        initialRotation = transform.rotation.eulerAngles.z;
    }

    private void Update()
    {
        // Calculate the new rotation angle.
        float newRotation = initialRotation + pingPongDirection * Mathf.PingPong(Time.time * pingPongSpeed, rotationAmount);

        // Apply the rotation to the object.
        transform.rotation = Quaternion.Euler(rotationAxis * newRotation);

        // Reverse the ping-pong direction at the ends.
        if (newRotation >= initialRotation + rotationAmount || newRotation <= initialRotation)
        {
            pingPongDirection *= -1.0f;
        }
    }
}
