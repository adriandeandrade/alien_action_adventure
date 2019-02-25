using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    bool isHighlighted = false;

    public void HighlightItem()
    {
        if(!isHighlighted)
        {
            isHighlighted = true;
            Debug.Log("In range of item.");
        }
    }
}
