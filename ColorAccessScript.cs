using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitySimpleLiquid
{
    public class ColorAccessScript : MonoBehaviour
    {
        public Split splitScript;
        public FluidContainer fluidContainer;

        private void Start()
        {
            // Assuming you have references to the Split and FluidContainer scripts
            // If not, you can find the components using FindObjectOfType<Split>() and FindObjectOfType<FluidContainer>()
            splitScript = FindObjectOfType<Split>();
            fluidContainer = FindObjectOfType<FluidContainer>();
        }

        private void Update()
        {
            if (splitScript != null && fluidContainer != null)
            {
                Color particleColor = splitScript.ParticleColor;
                fluidContainer.LiquidColor = particleColor;
            }
        }
    }
}




