
using System;
using TMPro;
using UnityEngine;

public class UI_GameTime : MonoBehaviour
{
    [SerializeField] private RSO_Timer rsoTimer;
    
    [SerializeField] private TMP_Text timeText;

    private void OnEnable() => rsoTimer.OnChanged += UpdateUi;
    private void OnDisable() => rsoTimer.OnChanged -= UpdateUi;

    private void UpdateUi(float value) => timeText.text = value.ToString("0.00");
}