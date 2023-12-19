using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class count : MonoBehaviour

{
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle hit");
    }
   
  
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected!");

        // Log information about the collision
        Debug.Log("Collided with: " + collision.gameObject.name);
        Debug.Log("Collision relative velocity: " + collision.relativeVelocity);
        Debug.Log("Collision contact points: ");

        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log("Point: " + contact.point + ", Normal: " + contact.normal);
        }
    }




}




