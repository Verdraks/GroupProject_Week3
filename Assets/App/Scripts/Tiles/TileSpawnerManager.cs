using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSpawnerManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int collectibleCount;
    [SerializeField] private int powerUpCount;

    [Header("References")]
    [SerializeField] private GameObject collectiblePrefab;
    [SerializeField] private GameObject powerUpPrefab;
    [Space(5)]
    [SerializeField] private Tilemap tilemapInclude, tilemapExclude;

    private void Start()
    {
        GenerateCollectibles();
    }

    private void GenerateCollectibles()
    {
        List<Vector2> tilesAvailable = new List<Vector2>();

        var bound = tilemapInclude.cellBounds;
        
        for (int x = bound.xMin; x < bound.xMax; x++)
        for (int y = bound.yMin; y < bound.yMax; y++)
        {
            if (tilemapInclude.HasTile(new Vector3Int(x, y, 0)))
            {
                tilesAvailable.Add(new Vector2(x, y));
            }
        }
        
        bound = tilemapExclude.cellBounds;
        for(int x = bound.xMin; x < bound.xMax; x++)
        for (int y = bound.yMin; y < bound.yMax; y++)
        {
            if (tilemapExclude.HasTile(new Vector3Int(x, y, 0)))
            {
                tilesAvailable.Remove(new Vector2(x, y));
            }
        }

        for (int x = 0; x < collectibleCount; x++)
        {
            var pos = tilesAvailable[Random.Range(0, tilesAvailable.Count)];
            Instantiate(collectiblePrefab, pos, Quaternion.identity);
            tilesAvailable.Remove(pos);
        }
        
        for (int x = 0; x < powerUpCount; x++)
        {
            var pos = tilesAvailable[Random.Range(0, tilesAvailable.Count)];
            Instantiate(powerUpPrefab, pos, Quaternion.identity);
            tilesAvailable.Remove(pos);
        }
        
    }
}