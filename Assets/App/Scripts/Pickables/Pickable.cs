using UnityEngine;

public class Pickable : MonoBehaviour
{
    [Header("RSO")]
    [SerializeField] private RSO_Ressources rsoRessources;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rsoRessources.Value += 1;
            gameObject.SetActive(false);
        }
    }
}
