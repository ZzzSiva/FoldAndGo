using UnityEngine;

public class RotateOrigami : MonoBehaviour {
    
    public float rotationSpeed    = 0.3f;  // Rotation speed
    public float timeTouchStarted = 0;     //allows to calculate how long a user has touched the screen
    public bool  isTouching       = false; //Checks if there is a user touching the screen

    void Update() {
        // Check if the screen is being touched
        if(Input.touchCount == 1) {

            // Store the time when the touch started
            if(isTouching == false) {
                timeTouchStarted = Time.time;
                isTouching       = true;
            }

            // Calculate how long the touch lasted
            float touchDuration = Time.time - timeTouchStarted;

            // If the touch lasted less than a second
            if (touchDuration < 1.0f) {
               Vector2 fingerPosition = Input.GetTouch(0).position;

                // Get the previous finger position
                Vector2 previousFingerPosition = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;

                // Calculate the difference in position
                Vector2 fingerDelta = fingerPosition - previousFingerPosition;

                // Rotate the object based on the finger delta and the rotation speed
                transform.Rotate(Vector3.up, -fingerDelta.x * rotationSpeed);
            }
        }

        // Reset the touch status if there is no touch
        if (Input.touchCount == 0) {
            isTouching = false;
        }
    }
}