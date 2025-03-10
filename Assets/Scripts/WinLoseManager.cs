using System;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] GameObject panelWin;
    [SerializeField] RSE_CallWinGame RSE_CallWinGame;
    private void OnEnable()
    {
        RSE_CallWinGame.action += ActiveWinPanel;
    }
    private void OnDisable()
    {
        RSE_CallWinGame.action -= ActiveWinPanel;
    }
    private void ActiveWinPanel()
    {
        panelWin.SetActive(true);
    }
}
