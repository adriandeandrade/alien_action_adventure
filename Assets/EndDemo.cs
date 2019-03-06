using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDemo : MonoBehaviour
{
    public Text tanksText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            tanksText.gameObject.SetActive(true);
            Invoke("ExitGame", 1f);
        }
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
