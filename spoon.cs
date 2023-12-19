using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spoon : MonoBehaviour
{

[SerializeField]
private ParticleSystem defaultparticle;
private ParticleSystem particleSystemInstance;
[SerializeField]
private ParticleSystem coppersulphate;
private ParticleSystem copperparticleInstance;
[SerializeField]
private ParticleSystem ironpowder;
private ParticleSystem ironparticleInstance;
private bool isPlaying = false;

void Start()
{
    // Defaultparticles
    particleSystemInstance = Instantiate(defaultparticle, transform);
    
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
    
}

void Update()
    { 

    if (Input.GetKeyDown(KeyCode.P))
    {
        particleSystemInstance.Play();
        isPlaying = true;
    } 
    /* 
        if (transform.localRotation.eulerAngles.x <= 45 && isPlaying)
        {
            particleSystemInstance.Stop();
            isPlaying = false;

        }
        else if (transform.localRotation.eulerAngles.x > 45 && !isPlaying)
        {
            particleSystemInstance.Play();
            isPlaying = true;
        }*/
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

    private void OnTriggerEnter(Collider other)
    {
        AssetName asset = other.GetComponent<AssetName>();

        if (asset != null)
        {
            string assetName = asset.AssetNameProperty;

            if (assetName == "copperbottle")
            {
                particleSystemInstance.Stop(); // Stop the current particle system
                Destroy(particleSystemInstance.gameObject); // Destroy the current particle system instance

                // Create a new particle system instance for the coppersulphate
                particleSystemInstance = Instantiate(coppersulphate, transform);

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
            else if (assetName == "ironbottle")
            {
                particleSystemInstance.Stop(); // Stop the current particle system
                Destroy(particleSystemInstance.gameObject); // Destroy the current particle system instance

                // Create a new particle system instance for the ironpowder
                particleSystemInstance = Instantiate(ironpowder, transform);

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
        }
    }




}


