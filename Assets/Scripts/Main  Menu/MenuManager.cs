using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A Class responsible for handling most highlevel menu functionality
//Normally it'd control a number of smaller classes, each one of them handling its own screen
public class MenuManager : MonoBehaviour
{
    [SerializeField] Button startGameplayButton;
    private void Awake()
    {
        startGameplayButton.onClick.AddListener(RequestGameplay);
    }

    private void RequestGameplay()
    {
        startGameplayButton.enabled = false;
        SimplifiedEventManager.GameplayRequested.Invoke();
    }
}
