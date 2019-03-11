using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGenerator : MonoBehaviour
{
    public InteractableBaseInteractable elevatorButton;
    [SerializeField] private GameObject generatorOpenText;

    public void GeneratorButton()
    {
        elevatorButton.isInteractable = true;
        generatorOpenText.SetActive(true);
    }
}
