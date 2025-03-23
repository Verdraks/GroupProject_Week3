using System.Threading;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float ghostDuration;
    [SerializeField] private int movementPoints;

    [Header("RSO")]
    [SerializeField] private RSO_MovementPoints rsoMovementPoints;

    [Header("RSE")]
    [SerializeField] RSE_UpdateSpriteToFront RSE_UpdateSpriteToFront;
    [SerializeField] RSE_UpdateSpriteToBack RSE_UpdateSpriteToBack;
    [SerializeField] RSE_UpdateSpriteToLeft RSE_UpdateSpriteToLeft;
    [SerializeField] RSE_UpdateSpriteToRight RSE_UpdateSpriteToRight;
    [Space(5)]
    [SerializeField] private RSE_DiscoverTile rseDiscoverTile;

    [Header("RSF")]
    [SerializeField] private RSF_GetTileType rsfGetTileType;

    public Vector2 currentPos;

    private CountdownTimer ghostTimer;

    private void Awake()
    {
        currentPos = transform.position;

        rsoMovementPoints.Value = movementPoints;
        rseDiscoverTile.Call(currentPos);

        ghostTimer = new CountdownTimer(ghostDuration);

        ghostTimer.OnTimerStop = () => OnGhostEnd();
    }

    private void Update()
    {
        HandleTimers();
        GetInput();
    }

    private void HandleTimers()
    {
        ghostTimer.Tick(Time.deltaTime);
    }

    private void CheckMove(Vector2 direction)
    {
        TileType tileType = rsfGetTileType.Call(currentPos + direction);

        Debug.Log(tileType);

        if(tileType == TileType.Ground || ghostTimer.IsRunning)
        {
            rsoMovementPoints.Value -= 1;

            if (rsoMovementPoints.Value <= 0) Die();
            
            Move(direction);
        }
    }

    private void Move(Vector2 direction)
    {
        currentPos += direction;
        transform.position = new Vector3(Mathf.FloorToInt(currentPos.x), Mathf.FloorToInt(currentPos.y), transform.position.z);
        rseDiscoverTile.Call(currentPos);
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CheckMove(Vector2.up);
            RSE_UpdateSpriteToBack.Call();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            CheckMove(Vector2.down);
            RSE_UpdateSpriteToFront.Call();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            CheckMove(Vector2.right);
            RSE_UpdateSpriteToRight.Call();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            CheckMove(Vector2.left);
            RSE_UpdateSpriteToLeft.Call();
        }
    }

    public void ActiveGhostMode()
    {
        ghostTimer.Start();
    }

    private void OnGhostEnd()
    {
        if (rsfGetTileType.Call(currentPos) == TileType.Wall) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Die()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
