using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomObject : MonoBehaviour
{
    public GameObject objectToZoom;

    public float zoomSpeed = 0.03f;

    private Vector2 firstTouchPosition;


    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // On first touch, consider the initial position to compare relative movement later
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                firstTouchPosition = touch1.position - touch2.position;
            }
            // Compares relative movement of the two inputs
            else
            {
                Vector2 currentTouchPosition = touch1.position - touch2.position;
                float zoomFactor = currentTouchPosition.magnitude - firstTouchPosition.magnitude;
                objectToZoom.transform.localScale = new Vector3(objectToZoom.transform.localScale.x+zoomFactor * zoomSpeed * Time.deltaTime,
                                                                objectToZoom.transform.localScale.y+zoomFactor * zoomSpeed * Time.deltaTime,
                                                                objectToZoom.transform.localScale.z+zoomFactor * zoomSpeed * Time.deltaTime);
            }
        }
    }
}