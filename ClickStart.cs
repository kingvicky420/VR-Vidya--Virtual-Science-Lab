using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStart : MonoBehaviour

{
    [SerializeField]
    private ParticleSystem particleSystemPrefab;
    private ParticleSystem particleSystemInstance;
    private bool isPlaying = false;
    private float rotationThreshold = 90;
    public bool isClickable = true;

    void Start()
    {
    // Create a new particle system instance
    particleSystemInstance = Instantiate(particleSystemPrefab, transform);

    // Calculate the object's scale along each axis
    Vector3 objectScale = transform.lossyScale;

    // Adjust particle system scale based on object size
    Vector3 particleSystemScale = particleSystemInstance.transform.localScale;
    particleSystemScale.x /= objectScale.x;
    particleSystemScale.y /= objectScale.y;
    particleSystemScale.z /= objectScale.z;
    particleSystemInstance.transform.localScale = particleSystemScale;

    // Move particle system to the center of the object
    Bounds objectBounds = CalculateObjectBounds();
    Vector3 objectCenter = objectBounds.center;

    // Adjust particle system position in the Y direction
    float yOffset = objectBounds.extents.y * objectScale.y;
    objectCenter.y += yOffset;

    particleSystemInstance.transform.position = objectCenter;

    // Attach the particle system to the GameObject
    particleSystemInstance.transform.SetParent(transform);
    particleSystemInstance.Stop();
    isPlaying = false;
    }

    void OnMouseDown()
    {
        if (isClickable)
        {
            if (!isPlaying)
            {
                StartParticleSystem();
            }
            else
            {
                StopParticleSystem();
            }
        }
    }

    private void StartParticleSystem()
    {
        particleSystemInstance.Play(); // Play the particle system
        isPlaying = true;
    }

    private void StopParticleSystem()
    {
        particleSystemInstance.Stop(); // Stop the particle system
        isPlaying = false;
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
