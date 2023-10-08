using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for wrapping everything 
[RequireComponent(typeof(BoxCollider2D))]
public class ScreenWrapper : MonoBehaviour
{
    [SerializeField] BoxCollider2D wrappingBoxCollider;
    //If an asteroid got destroyed offscreen, there's a chance it splits outside of proper bounds
    //Ideally this would be handled by a check at the point of splitting but a second slightly bigger collider is faster
    [SerializeField] BoxCollider2D wrappingBoxColliderSafetyNet;
    Camera mainCam;
    [SerializeField] Vector2 offset;
    Vector2 screenCenterPos;
    private void Awake()
    {
        mainCam = Camera.main;
        float cameraHeight = 2f * mainCam.orthographicSize;
        float cameraWidth = cameraHeight * mainCam.aspect;
        screenCenterPos = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, mainCam.nearClipPlane));
        // Set the size of the Box Collider
        wrappingBoxCollider.size = new Vector2(cameraWidth + offset.x, cameraHeight + offset.y);
        wrappingBoxColliderSafetyNet.size = new Vector2(cameraWidth + offset.x*4, cameraHeight + offset.y*4);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null)
            WrapTransform(collision.attachedRigidbody.transform);
        else
            WrapTransform(collision.transform);
    }
    void WrapTransform(Transform transform)
    {
        var currentViewPortPosition = mainCam.WorldToViewportPoint(transform.position);
        Vector2 newPos = transform.position;    //Will be used to warp position

        if (currentViewPortPosition.x > 1 || currentViewPortPosition.x < 0)//Wrap around X
        {
            //Warp Around X
            newPos.x *= -1;
            var centerScreenNormalizedDirection = (screenCenterPos - newPos).normalized;
            newPos.x += centerScreenNormalizedDirection.x * offset.x;

            transform.position = newPos;

        }
        else if (currentViewPortPosition.y > 1 || currentViewPortPosition.y < 0)//Wrap around Y
        {
            newPos.y *= -1;
            var centerScreenNormalizedDirection = (screenCenterPos - newPos).normalized;
            newPos.y += centerScreenNormalizedDirection.y * offset.x;

            transform.position = newPos;

        }
        transform.position = newPos;
    }

}
