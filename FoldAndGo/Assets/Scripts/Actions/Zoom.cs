using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // La caméra de la scène
    public Camera camera;

    // La distance minimale et maximale du zoom
    public float minZoom = 10f;
    public float maxZoom = 100f;

    // La vitesse du zoom
    public float zoomSpeed = 10f;

    // La position initiale du touché
    private Vector2 initialTouchPosition;

    // Met à jour le zoom en fonction des inputs de l'utilisateur
    void Update()
    {
        // Récupère l'input de zoom
        if (Input.touchCount == 2)
        {
            // Récupère les deux touches
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Si c'est le premier frame où les touches sont détectées, enregistre leur position initiale
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialTouchPosition = touch1.position - touch2.position;
            }
            // Sinon, calcule la distance actuelle entre les touches et l'applique au zoom
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
