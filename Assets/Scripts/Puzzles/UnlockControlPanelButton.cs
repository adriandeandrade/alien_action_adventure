using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockControlPanelButton : MonoBehaviour
{
    public InteractableBaseInteractable controlPanel;

    public void UnlockButton()
    {
        controlPanel.isInteractable = true;
    }
}
