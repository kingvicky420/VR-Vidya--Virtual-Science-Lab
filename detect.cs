using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect : MonoBehaviour
{
    // Called when particles collide with the object
   

    private void OnParticleCollision(GameObject other)
    {
        // Check if the collided object has a ParticleSystem component
        ParticleSystem collidedParticleSystem = other.GetComponent<ParticleSystem>();
        if (collidedParticleSystem != null)
        {
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[collidedParticleSystem.particleCount];

            // Get the particles from the collided particle system
            int particleCount = collidedParticleSystem.GetParticles(particles);

            for (int i = 0; i < particleCount; i++)
            {
                // Access the color of each particle
                Color particleColor = particles[i].GetCurrentColor(collidedParticleSystem);

                Debug.Log("Particle " + i + " color: " + particleColor);
            }
        }
    }
}


  

    
