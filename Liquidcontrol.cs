using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquidcontrol : MonoBehaviour

{
    public float scale = 1f;    // The scale value to control the shader
    private Renderer renderer;

    private void Start()
    {
        // Get the renderer component
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        // Update the shader property with the scale value
        renderer.material.SetFloat("_Scale", scale);
    }
}
