using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class MapController : MonoBehaviour
{
    private static MapController _instance;

    public static MapController Instance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField] private Tilemap _tilemap;
    private Dictionary<Vector2Int, TerrainTile> _tiles = new Dictionary<Vector2Int, TerrainTile>();
    public int width = 10;
    public int height = 6;
    public TerrainTile[] possibleTiles;

    public void Generate()
    {
        GenerateTiles();
        UpdateMap();
    }

    private void UpdateMap()
    {
        _tilemap.ClearAllTiles();
        _tiles.ToList().ForEach(pair => { _tilemap.SetTile((Vector3Int) pair.Key, pair.Value.tile); });
    }

    public void ChangeTile(Vector2Int position, TerrainTile tile)
    {
        _tiles[position] = tile;
        _tilemap.SetTile((Vector3Int) position, tile.tile);
    }

    private void GenerateTiles()
    {
        _tiles.Clear();

        fillFirstRowWithWater();
        fillAllButFirstRowWithSand();
    }

    private void fillFirstRowWithWater() {
        for (int y = 0; y < height; y++)
        {
            Vector2Int position = new Vector2Int(0, y);
            TerrainTile tile = possibleTiles[1];
            _tiles.Add(position, tile);
        }
    }

    private void fillAllButFirstRowWithSand() {
        for (int x = 1; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2Int position = new Vector2Int(x, y);
                TerrainTile tile = possibleTiles[0];
                _tiles.Add(position, tile);
            }
        }
    }

    public Vector2Int[] GetNeighbors(Vector2Int pos)
    {
        var odd = pos.y % 2 == 1;
        if (odd)
        {
            return new[]
            {
                pos + Vector2Int.down,
                pos + Vector2Int.left,
                pos + Vector2Int.right,
                pos + Vector2Int.up,
                pos + Vector2Int.right + Vector2Int.up,
                pos + Vector2Int.right + Vector2Int.down,
            };
        }
        else
        {
            return new[]
            {
                pos + Vector2Int.down,
                pos + Vector2Int.left,
                pos + Vector2Int.right,
                pos + Vector2Int.up,
                pos + Vector2Int.left + Vector2Int.up,
                pos + Vector2Int.left + Vector2Int.down,
            };
        }
    }
}