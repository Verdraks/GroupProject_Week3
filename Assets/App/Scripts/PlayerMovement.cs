using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("RSE")]
    [SerializeField] RSE_UpdateSpriteToFront RSE_UpdateSpriteToFront;
    [SerializeField] RSE_UpdateSpriteToBack RSE_UpdateSpriteToBack;
    [SerializeField] RSE_UpdateSpriteToLeft RSE_UpdateSpriteToLeft;
    [SerializeField] RSE_UpdateSpriteToRight RSE_UpdateSpriteToRight;
    [SerializeField] float playerSpeed;
    private Vector2Int targetPos;
    private void Awake()
    {
        targetPos = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        transform.position = (Vector2)targetPos;
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
}
