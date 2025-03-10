using UnityEngine;

public class ChangePlayerVisual : MonoBehaviour
{
    [Header("RSE")]
    [SerializeField] RSE_UpdateSpriteToFront RSE_UpdateSpriteToFront;
    [SerializeField] RSE_UpdateSpriteToBack RSE_UpdateSpriteToBack;
    [SerializeField] RSE_UpdateSpriteToLeft RSE_UpdateSpriteToLeft;
    [SerializeField] RSE_UpdateSpriteToRight RSE_UpdateSpriteToRight;
    [Header("References")]
    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] Sprite playerFront;
    [SerializeField] Sprite playerBack;
    [SerializeField] Sprite playerLeft;
    [SerializeField] Sprite playerRight;
    private void OnEnable()
    {
        RSE_UpdateSpriteToFront.action += SpriteFront;
        RSE_UpdateSpriteToBack.action += SpriteBack;
        RSE_UpdateSpriteToLeft.action += SpriteLeft;
        RSE_UpdateSpriteToRight.action += SpriteRight;
    }
    private void OnDisable()
    {
        RSE_UpdateSpriteToFront.action -= SpriteFront;
        RSE_UpdateSpriteToBack.action -= SpriteBack;
        RSE_UpdateSpriteToLeft.action -= SpriteLeft;
        RSE_UpdateSpriteToRight.action -= SpriteRight;
    }
    private void SpriteFront()
    {
        playerSpriteRenderer.sprite = playerFront;
    }
    private void SpriteBack()
    {
        playerSpriteRenderer.sprite = playerBack;
    }
    private void SpriteLeft()
    {
        playerSpriteRenderer.sprite = playerLeft;
    }
    private void SpriteRight()
    {
        playerSpriteRenderer.sprite = playerRight;
    }
}
