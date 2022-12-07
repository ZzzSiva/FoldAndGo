using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotate : MonoBehaviour
{
   
    public float rotationSpeed = 1.0f; // Rotation speed

    void Update() {
        // Get the current finger position
        Vector2 fingerPos = Input.GetTouch(0).position;

        // Get the previous finger position
        Vector2 previousFingerPos = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;

        // Calculate the difference in position
        Vector2 fingerDelta = previousFingerPos - fingerPos;

        // Rotate the object based on the finger delta and the rotation speed
        transform.Rotate(Vector3.up, fingerDelta.x * rotationSpeed);
    }  
}
