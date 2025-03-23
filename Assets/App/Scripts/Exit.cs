using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string levelToLoad;
    [SerializeField] private int requiredQuantity;

    [Header("RSO")]
    [SerializeField] private RSO_Ressources rsoRessource;

    private void Awake()
    {
        rsoRessource.Value = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && rsoRessource.Value >= requiredQuantity)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
