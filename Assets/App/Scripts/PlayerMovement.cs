using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private int fogRevealRadius;

    [Header("References")]
    [SerializeField] private Tilemap fogTilemap;

    [Header("RSE")]
    [SerializeField] RSE_UpdateSpriteToFront RSE_UpdateSpriteToFront;
    [SerializeField] RSE_UpdateSpriteToBack RSE_UpdateSpriteToBack;
    [SerializeField] RSE_UpdateSpriteToLeft RSE_UpdateSpriteToLeft;
    [SerializeField] RSE_UpdateSpriteToRight RSE_UpdateSpriteToRight;

    private Vector2Int targetPos;

    private void Awake()
    {
        targetPos = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        transform.position = (Vector2)targetPos;
        RevealArea(targetPos);
    }
    void Update()
    {
        var moving = (Vector2)transform.position != targetPos;

        if (moving)
        {
            MoveTowardsTargetPosition();
        }
        else
        {
            SetNewTargetPosition();
        }
    }

    private void MoveTowardsTargetPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, playerSpeed * Time.deltaTime);
    }

    private void SetNewTargetPosition()
    {
        if (Input.GetKey(KeyCode.W))
        {
            targetPos += Vector2Int.up;
            RSE_UpdateSpriteToBack.Call();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetPos += Vector2Int.down;
            RSE_UpdateSpriteToFront.Call();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetPos += Vector2Int.right;
            RSE_UpdateSpriteToRight.Call();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            targetPos += Vector2Int.left;
            RSE_UpdateSpriteToLeft.Call();
        }
    }

    private void RevealArea(Vector2Int position)
    {
        Vector3Int tilePosition = new Vector3Int(position.x, position.y, 0);
        if (fogTilemap.HasTile(tilePosition))
        {
            fogTilemap.SetTile(tilePosition, null);
        }
    }
}