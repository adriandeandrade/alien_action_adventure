using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    public Color onMouseOverColor;

    Color originalColor;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        originalColor = meshRenderer.material.color;
    }

    private void OnMouseOver()
    {
        meshRenderer.material.color = onMouseOverColor;

        Debug.Log("hovered object");
    }

    private void OnMouseExit()
    {
        meshRenderer.material.color = originalColor;
    }
}
