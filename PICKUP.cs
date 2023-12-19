using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PICKUP : MonoBehaviour


{
    private Rigidbody attachedRigidbody; // Reference to the attached Rigidbody
    private bool isAttached = false; // Flag to track attachment status
    public Transform equipPosition; // The position to move the attached object to

    private void OnCollisionEnter(Collision collision)
    {
        if (isAttached)
            return; // Skip attachment if the object is already attached

        // Check if the colliding object has a Rigidbody component
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        // If the colliding object has a Rigidbody, attach it to the current object
        if (rb != null)
        {
            rb.isKinematic = true; // Disable physics simulation on the colliding object
            rb.transform.parent = transform; // Set the current object as the parent of the colliding object

            attachedRigidbody = rb; // Store the reference to the attached Rigidbody
            isAttached = true; // Update the attachment status

            // Move the attached object to the specified equip position
            attachedRigidbody.transform.position = equipPosition.position;
            attachedRigidbody.transform.rotation = equipPosition.rotation;
        }
    }

    private void Update()
    {
        // Check if the "D" key is pressed and the object is attached
        if (Input.GetKeyDown(KeyCode.D) && isAttached)
        {
            DropObject();
        }
    }

    private void DropObject()
    {
        if (attachedRigidbody != null)
        {
            attachedRigidbody.isKinematic = false; // Enable physics simulation on the attached object
            attachedRigidbody.transform.parent = null; // Remove the parent of the attached object

            attachedRigidbody = null; // Clear the reference to the attached Rigidbody
            isAttached = false; // Update the attachment status
        }
    }
}




