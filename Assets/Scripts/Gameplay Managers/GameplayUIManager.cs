using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI endMenuBodyText;
    [SerializeField] TextMeshProUGUI killCountText;
    [SerializeField] GameObject endMenu;
    [SerializeField] Button backToMainMenuButton;
    int asteroidKillCount;
    float timeSurvived;
    private void Awake()
    {
        backToMainMenuButton.onClick.AddListener(SimplifiedEventManager.MainMenuRequested.Invoke);
        Init();
    }

    private void Init()
    {
        livesText.text = FindObjectOfType<ShipHealthComponent>().NumberOfLives.ToString();
    }

    private void OnEnable()
    {
        SimplifiedEventManager.AsteroidDeath.AddListener(StackAsteroids);
        SimplifiedEventManager.PlayerDeath.AddListener(HandlePlayerDeath);
    }
    private void OnDisable()
    {
        SimplifiedEventManager.AsteroidDeath.RemoveListener(StackAsteroids);
        SimplifiedEventManager.PlayerDeath.RemoveListener(HandlePlayerDeath);
    }
    private void HandlePlayerDeath(int availableLives)
    {
        if (availableLives < 0)
        {
            ShowEndMenu();
        }
        else
        {
            livesText.text = availableLives.ToString();
        }
    }

    private void ShowEndMenu()
    {
        TimeSpan timeSurvivedSpan = TimeSpan.FromSeconds(timeSurvived);
        endMenuBodyText.text = $"Time Survived: {string.Format("{0}:{1:00}", (int)timeSurvivedSpan.TotalMinutes, timeSurvivedSpan.Seconds)}\nKill Count: {asteroidKillCount}";
        endMenu.SetActive(true);
    }

    private void StackAsteroids()
    {
        asteroidKillCount++;
        killCountText.text = asteroidKillCount.ToString();
    }
    private void Update()
    {
        timeSurvived += Time.deltaTime;
    }
}
