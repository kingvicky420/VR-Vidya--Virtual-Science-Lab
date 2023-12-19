using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetName : MonoBehaviour
{
    [SerializeField]
    private string assetName = ""; // Name of the asset

    public string AssetNameProperty
    {
        get { return assetName; }
        set { assetName = value; }
    }

    private void Start()
    {
        // Assign a default name to the asset if not already set
        if (string.IsNullOrEmpty(assetName))
        {
            assetName = "Asset" + transform.GetSiblingIndex();
        }
    }
}
