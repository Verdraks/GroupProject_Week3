using UnityEngine;

public class Exit : MonoBehaviour
{
    [Header("RSE")]
    [SerializeField] RSE_CanFinishLevel RSE_CanFinishLevel;
    [SerializeField] RSE_CallWinGame RSE_CallWinGame;
    bool canFinish;

    private void OnEnable()
    {
        RSE_CanFinishLevel.action += SetBool;
    }
    private void OnDisable()
    {
        RSE_CanFinishLevel.action -= SetBool;
    }
    private void SetBool(bool value)
    {
        canFinish = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (canFinish)
            {
                RSE_CallWinGame.RaiseEvent();
            }
        }
    }
}
