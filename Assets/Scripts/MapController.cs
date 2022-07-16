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

    private void GenerateTiles()
    {
        _tiles.Clear();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2Int position = new Vector2Int(x, y);
                TerrainTile tile = possibleTiles[Random.Range(0, possibleTiles.Length)];
                _tiles.Add(position, tile);
            }
        }
    }
}