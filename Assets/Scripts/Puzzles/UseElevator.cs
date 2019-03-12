using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseElevator : MonoBehaviour
{
    [SerializeField] private LevelFader levelFader;

    private void Awake()
    {
        levelFader = FindObjectOfType<LevelFader>();
    }

    public void OnUseElevator()
    {
        levelFader.FadeToLevel(1);
    }
}
