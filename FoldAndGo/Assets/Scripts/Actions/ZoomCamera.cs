using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // Select camera on which the zoom will be applied
    public Camera camera;

    public float minZoom = 10f;
    public float maxZoom = 100f;

 
    public float zoomSpeed = 10f;

    private Vector2 initialTouchPosition;


    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // On first touch, consider the initial position to compare relative movement later
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialTouchPosition = touch1.position - touch2.position;
            }
            // Compares relative movement of the two inputs
            else
            {
                Vector2 currentTouchPosition = touch1.position - touch2.position;
                float zoomFactor = currentTouchPosition.magnitude - initialTouchPosition.magnitude;
                camera.fieldOfView -= zoomFactor * zoomSpeed * Time.deltaTime;
                camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, minZoom, maxZoom);
            }
        }
    }
}