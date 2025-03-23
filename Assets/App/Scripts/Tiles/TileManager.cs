using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TilemapData[] tilemapDatas;
    [SerializeField] private Tilemap fog;

    [Header("RSE")]
    [SerializeField] private RSE_DiscoverTile rseDiscoverTile;

    [Header("RSF")]
    [SerializeField] private RSF_GetTileType rsfGetTileType;

    private readonly Dictionary<Vector2Int, List<TileType>> tiles = new();

    private void OnEnable()
    {
        rseDiscoverTile.action += DiscoverTile;
        rsfGetTileType.Action += GetTileType;
    }
    private void OnDisable()
    {
        rseDiscoverTile.action -= DiscoverTile;
        rsfGetTileType.Action -= GetTileType;
    }

    private void Awake()
    {
        GenerateMapInDictionnary();
    }

    private TileType GetTileType(Vector2 targetPosition)
    {
        Vector2Int targetTilePosition = new Vector2Int(Mathf.FloorToInt(targetPosition.x), Mathf.FloorToInt(targetPosition.y));

        if(tiles.TryGetValue(targetTilePosition, out var tileTypes))
        {
            foreach(TileType tileType in tileTypes)
            {
                return tileType;
            }
        }

        return TileType.None;
    }

    private void DiscoverTile(Vector2 position)
    {
        Vector3Int targetTilePosition = new Vector3Int(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y), 0);
        fog.SetTile(targetTilePosition, null);
    }

    private void GenerateMapInDictionnary()
    {
        tiles.Clear();

        foreach(var tilemapData in tilemapDatas)
        {
            foreach(var position in tilemapData.tilemap.cellBounds.allPositionsWithin)
            {
                if (tilemapData.tilemap.HasTile(position))
                {
                    Vector2Int pos = new Vector2Int(position.x, position.y);

                    if (!tiles.ContainsKey(pos))
                    {
                        tiles[pos] = new List<TileType>() { Capacity = 2 };
                    }
                    tiles[pos].Add(tilemapData.tilemapType);
                }
            }
        }
    }
}

[Serializable]
public struct TilemapData
{
    public TileType tilemapType;
    public Tilemap tilemap;
}

public enum TileType
{
    None,
    Ground,
    Wall,
}