using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlecontroller : MonoBehaviour

{
    [SerializeField]
    private ParticleSystem particleSystemPrefab;
    private ParticleSystem particleSystemInstance;
    private bool isPlaying = false;
    private float rotationThreshold = 90;

    void Start()
    {
        // Create a new particle system instance
        particleSystemInstance = Instantiate(particleSystemPrefab, transform);

        // Adjust particle system scale based on object size
        Vector3 objectSize = transform.lossyScale;
        particleSystemInstance.transform.localScale = objectSize;

        // Move particle system to the center of the object
        Bounds objectBounds = CalculateObjectBounds();
        Vector3 objectCenter = objectBounds.center;
        particleSystemInstance.transform.position = objectCenter;

        // Attach the particle system to the GameObject
        particleSystemInstance.transform.SetParent(transform);
        particleSystemInstance.Stop();
        isPlaying = false;
    }

    void Update()
    {
           

        /// Check if the local rotation on the X-axis is greater than the threshold
        if ((transform.localRotation.eulerAngles.x > 45 && transform.localRotation.eulerAngles.x < 315) && !isPlaying)
        {
            particleSystemInstance.Play(); // Play the particle system
            isPlaying = true;
        }
        else if ((transform.localRotation.eulerAngles.x <= 45 && transform.localRotation.eulerAngles.x < 315)&& isPlaying)
        {
            particleSystemInstance.Stop(); // Stop the particle system
            isPlaying = false;
        }    
    }

    private Bounds CalculateObjectBounds()
    {
        Renderer objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            return objectRenderer.bounds;
        }
        else
        {
            Collider objectCollider = GetComponent<Collider>();
            if (objectCollider != null)
            {
                return objectCollider.bounds;
            }
        }
        // If no Renderer or Collider is found, use a default bounds
        return new Bounds(transform.position, Vector3.zero);
    }
}




