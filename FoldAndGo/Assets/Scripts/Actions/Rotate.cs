using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotate : MonoBehaviour
{
    
    public float rotationSpeed = 1.0f;  // Rotation speed
    public bool isTouching = false;     //Checks if there is a user touching the screen
    public float timeTouchStarted = 0;  //allows to calculate how long a user has touched the screen
    void Update()
    {
        // Check if the screen is being touched
        if (Input.touchCount > 0)
        {
            // Store the time when the touch started
            if (isTouching==false)
            {
            timeTouchStarted = Time.time;
            isTouching = true;
            }
            // Calculate how long the touch lasted
            float touchDuration = Time.time - timeTouchStarted;

            // If the touch lasted less than a second
            if (touchDuration < 1.0f)
            {
               Vector2 fingerPos = Input.GetTouch(0).position;

            // Get the previous finger position
            Vector2 previousFingerPos = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;

            // Calculate the difference in position
            Vector2 fingerDelta = previousFingerPos - fingerPos;

            // Rotate the object based on the finger delta and the rotation speed
            transform.Rotate(Vector3.up, fingerDelta.x * rotationSpeed);
            }

        }
        // Reset the touch status if there is no touch
        if (Input.touchCount == 0)
        {
        isTouching = false;
        }
        
    }
}
