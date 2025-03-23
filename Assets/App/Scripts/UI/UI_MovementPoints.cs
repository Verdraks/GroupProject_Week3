using TMPro;
using UnityEngine;
public class UI_MovementPoints : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text movementPointsText;

    [Header("RSO")]
    [SerializeField] private RSO_MovementPoints rsoMovementPoints;

    private void OnEnable() => rsoMovementPoints.OnChanged += UpdateText;
    private void OnDisable() => rsoMovementPoints.OnChanged += UpdateText;

    private void Awake()
    {
        UpdateText(rsoMovementPoints.Value);
    }

    private void UpdateText(int value)
    {
        movementPointsText.text = "MovementPoints: " + value.ToString();
    }
}