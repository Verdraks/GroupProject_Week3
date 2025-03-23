using UnityEngine;
public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().ActiveGhostMode();
            gameObject.SetActive(false);
        }
    }
}