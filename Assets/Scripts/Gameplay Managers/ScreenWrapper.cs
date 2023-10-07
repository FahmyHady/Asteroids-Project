using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScreenWrapper : MonoBehaviour
{
    BoxCollider2D wrappingBoxCollider;
    Camera mainCam;
    [SerializeField] Vector2 offset;
    private void Awake()
    {
        mainCam = Camera.main;
        wrappingBoxCollider = GetComponent<BoxCollider2D>();
        float cameraHeight = 2f * mainCam.orthographicSize;
        float cameraWidth = cameraHeight * mainCam.aspect;

        // Set the size of the Box Collider
        wrappingBoxCollider.size = new Vector2(cameraWidth + offset.x, cameraHeight + offset.y);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
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
           // newPos.x += offset.x;

            transform.position = newPos;

        }
        else if (currentViewPortPosition.y > 1 || currentViewPortPosition.y < 0)//Wrap around Y
        {
            newPos.y *= -1;
          //  newPos.y += offset.y;
            transform.position = newPos;

        }
        transform.position = newPos;
    }
}
