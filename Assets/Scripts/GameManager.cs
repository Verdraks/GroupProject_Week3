using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("RSE")]
    [SerializeField] RSE_PickUpObject RSE_PickUpObject;
    [SerializeField] RSE_CallWinGame callWinGame;
    private int pickUpCount;

    private void OnEnable()
    {
        RSE_PickUpObject.action += UpdatePickUpCount;
    }
    private void OnDisable()
    {
        RSE_PickUpObject.action -= UpdatePickUpCount;
    }
    void Start()
    {
        pickUpCount = GameObject.FindGameObjectsWithTag("PickUp").Length;
        Debug.Log(pickUpCount);
    }
    private void UpdatePickUpCount()
    {
        pickUpCount--;
        if (pickUpCount <= 0)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        callWinGame.RaiseEvent();
    }
}
