using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] RSE_PickUpObject pickUpObject;
    [SerializeField] GameObject pickUpPrefabs;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pickUpObject.Call();
            Destroy(pickUpPrefabs);
        }
    }
}
