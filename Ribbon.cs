using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ribbon : MonoBehaviour

{
    [SerializeField]
    private ParticleSystem fire;
    private bool hasPlayed = false;

    private void OnParticleCollision(GameObject other)
    {
        // Check if the fire particles have already played
        if (!hasPlayed)
        {
            // Get the bounds of the object
            Renderer renderer = GetComponent<Renderer>();
            Bounds bounds = renderer.bounds;

            // Calculate the center of the object
            Vector3 center = bounds.center;

            // Instantiate the fire particle system at the center of the object
            ParticleSystem newFire = Instantiate(fire, center, Quaternion.identity);

            // Attach the fire particle system to the object
            newFire.transform.parent = transform;

            // Start the particle system
            newFire.Play();

            // Adjust the size of the fire particle system
            // Example: Decrease the size by 50%
            var mainModule = newFire.main;
            mainModule.startSizeMultiplier *= 0.5f;

            hasPlayed = true;
        }
    }
}


/*{
    [SerializeField]
    private ParticleSystem fire;

    private void OnParticleCollision(GameObject other)
    {
        // Get the bounds of the object
        Renderer renderer = GetComponent<Renderer>();
        Bounds bounds = renderer.bounds;

        // Calculate the center of the object
        Vector3 center = bounds.center;

        // Instantiate the fire particle system at the center of the object
        ParticleSystem newFire = Instantiate(fire, center, Quaternion.identity);

        // Attach the fire particle system to the object
        newFire.transform.parent = transform;

        // Adjust the size of the fire particle system
        // Example: Decrease the size by 50%
        var mainModule = newFire.main;
        mainModule.startSizeMultiplier *= 0.5f;
    }
}*/




