using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickmove : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging;

    private void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f)) + offset;
            newPosition.x = transform.position.x; // Keep the original x-position
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private bool isObjectSelected = false;
    private Vector3 mouseStartPosition;
    private float rotationSpeed = 5.0f;

    void Update()
    {
        // Check if left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Cast a ray to detect the clicked object
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is this game object
                if (hit.transform == transform)
                {
                    isObjectSelected = true;
                    mouseStartPosition = Input.mousePosition;
                }
            }
        }

        // Check if left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            isObjectSelected = false;
        }

        // Rotate the object if it's selected and mouse is being scrolled
        if (isObjectSelected && Input.mouseScrollDelta.y != 0)
        {
            float scrollDirection = Input.mouseScrollDelta.y > 0 ? -1 : 1;
            float rotationAmount = rotationSpeed * scrollDirection;

            transform.Rotate(rotationAmount, 0, 0, Space.Self);
        }
    }
}
