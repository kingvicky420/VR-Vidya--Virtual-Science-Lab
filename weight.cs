using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weight : MonoBehaviour

{
    public TextMeshProUGUI massText;
    private float totalMass = 0f;

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Check if the collided object has a Rigidbody component
        Rigidbody collidedRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (collidedRigidbody != null)
        {
            float mass = collidedRigidbody.mass;
            totalMass += mass;
        }
        else
        {
           // Debug.Log("Collided object does not have a Rigidbody component.");
        }

        UpdateMassText();

        // Perform other collision-related actions here
    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("Collision exited with: " + collision.gameObject.name);

        // Check if the exiting object has a Rigidbody component
        Rigidbody exitedRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (exitedRigidbody != null)
        {
            float mass = exitedRigidbody.mass;
            totalMass -= mass;
        }
        else
        {
            Debug.Log("Exiting object does not have a Rigidbody component.");
        }

        UpdateMassText();

        // Perform other collision exit-related actions here
    }

    private void UpdateMassText()
    {
        if (massText != null)
        {
            massText.text = totalMass.ToString("F3");
        }
    }
}









