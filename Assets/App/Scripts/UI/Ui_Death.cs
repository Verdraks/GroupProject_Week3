using System;
using UnityEngine;
public class Ui_Death : MonoBehaviour
{
    //[Header("Settings")]

    [Header("Reference")] 
    [SerializeField] private GameObject content;
    
    [Header("Input")] 
    [SerializeField] private RSE_PlayerDie rsePlayerDie;

    private Action _onPlayerDieAction;

    private void Awake()
    {
        _onPlayerDieAction = () => content.SetActive(true);
    }

    private void OnEnable()
    {
        content.SetActive(false);
        rsePlayerDie.action += _onPlayerDieAction;
    }

    private void OnDisable() => rsePlayerDie.action -= _onPlayerDieAction;
}