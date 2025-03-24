using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private float delayTransition;
    
    [Header("Output")]
    [SerializeField] private RSE_PlayerDie rsePlayerDie;

    private void OnEnable() => rsePlayerDie.action += EndGame;
    private void OnDisable() => rsePlayerDie.action -= EndGame;

    private void EndGame()
    {
        
        StartCoroutine(Wait());
    }


    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(delayTransition);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
