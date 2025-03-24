using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameTimer : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private float timeGame = 20f;
    [SerializeField] private RSO_Timer rsoTimer;
    
    private CountdownTimer _gameTimer;

    private void Awake()
    {
        _gameTimer = new CountdownTimer(timeGame);
        _gameTimer.OnTimerStop += GameEnd;
        rsoTimer.Value = 0f;
    }

    private void Start()
    {
        _gameTimer.Start();
    }

    private void Update()
    {
        _gameTimer.Tick(Time.deltaTime);
        rsoTimer.Value = _gameTimer.Time;
    }

    private void GameEnd()
    {
        SceneManager.LoadScene("MainMenu");
    }
}