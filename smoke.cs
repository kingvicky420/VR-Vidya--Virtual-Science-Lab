using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySimpleLiquid;

public class smoke : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem fire;
    private bool hasPlayed = false;
    public Transform equipPosition;

    private FluidContainer colourchange; // Reference to the FluidContainer script
    private Color targetColor; // The target color to transition to
    private float colorTransitionDuration = 10000f; // Duration of the color transition
    private float colorTransitionTimer; // Timer for the color transition

    private void Start()
    {
        colourchange = GetComponent<FluidContainer>();
    }

    private void Update()
    {
        // Perform the color transition if the timer is active
        if (colorTransitionTimer > 0f)
        {
            // Calculate the normalized progress of the color transition
            float progress = 1f - (colorTransitionTimer / colorTransitionDuration);

            // Smoothly transition the color from the previous color to the target color
            colourchange.LiquidColor = Color.Lerp(colourchange.LiquidColor, targetColor, progress);
            
            if (ColorEquals(colourchange.LiquidColor, Color.white))
            {
                StopSmoke();
            }

            // Update the color transition timer
            colorTransitionTimer -= Time.deltaTime;
        }

        // Rest of the code...
    }

    private bool ColorEquals(Color a, Color b, float threshold = 0.001f)
    {
        return Mathf.Abs(a.r - b.r) < threshold &&
               Mathf.Abs(a.g - b.g) < threshold &&
               Mathf.Abs(a.b - b.b) < threshold &&
               Mathf.Abs(a.a - b.a) < threshold;
    }

    private void OnParticleCollision(GameObject other)
    {
        // Check if the fire particles have already played
        if (!hasPlayed && other.name == "fire(Clone)")
        {
            // Check if the colorchange reference is not null
            if (colourchange != null)
            {
                // Set the target color to white for the color transition
                targetColor = Color.white;

                // Start the color transition
                colorTransitionTimer = colorTransitionDuration;
            }
            else
            {
                Debug.LogError("FluidContainer script is not found!");
            }

            // Get the bounds of the object
            Renderer renderer = GetComponent<Renderer>();
            Bounds bounds = renderer.bounds;

            // Calculate the center of the object
            Vector3 center = bounds.center;

            // Instantiate the smoke particle system at the equipPosition
            ParticleSystem smoke = Instantiate(fire, equipPosition.position, Quaternion.identity);

            // Attach the smoke particle system to the object
            smoke.transform.parent = equipPosition;

            // Start the particle system
            smoke.Play();

            // Adjust the size of the smoke particle system
            // Example: Decrease the size by 50%
            var mainModule = smoke.main;
            mainModule.startSizeMultiplier *= 0.5f;

            hasPlayed = true;
        }
    }

    private void StopSmoke()
    {
        // Find the smoke particle system attached to the equipPosition
        ParticleSystem smoke = equipPosition.GetComponentInChildren<ParticleSystem>();

        if (smoke != null)
        {
            // Stop and destroy the smoke particle system
            smoke.Stop();
            Destroy(smoke.gameObject);
        }
    }
}
