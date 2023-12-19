using System.Collections.Generic;
using UnityEngine;
using UnitySimpleLiquid;

public class colorchangescript : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private FluidContainer fluidContainer;
    private Material newMaterial;

    private void Start()
    {
        // Check if the Particle System is assigned
        if (particleSystem == null)
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        // Get the FluidContainer component attached to the same object
        fluidContainer = GetComponent<FluidContainer>();

        // Check if the Fluid Container is assigned
        if (fluidContainer == null)
        {
            Debug.LogError("FluidContainer component not found on the same object.");
            return;
        }

        // Create a new material with white color
        newMaterial = new Material(Shader.Find("Standard"));

        // Assign the new material to the Particle System's renderer
        var renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        renderer.material = newMaterial;
    }

    private void Update()
    {
        if (fluidContainer == null)
        {
            Debug.LogError("FluidContainer component not found on the same object.");
            return;
        }

        // Update the material color with the LiquidColor
        newMaterial.color = fluidContainer.LiquidColor;
    }
}
