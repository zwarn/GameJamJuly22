using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private static GameController _instance;

    public static GameController Instance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    private CursorController _cursorController;
    private MapController _mapController;

    private void Start()
    {
        _cursorController = CursorController.Instance();
        _mapController = MapController.Instance();
    }

    public void PlaceTile(Vector2Int tilePosition)
    {
        TerrainTile toPlace = SelectionUI.Instance().GETSelectedTile();
        _mapController.ChangeTile(tilePosition, toPlace);
        Produce();
        Events.Instance().OnMadeMove();
    }

    private void Produce()
    {
        _mapController.Tiles.ToList().ForEach(pair =>
        {
            var neighborPosition = _mapController.GetNeighbors(pair.Key);
            var terrains = neighborPosition.ToList().Where(pos => _mapController.Tiles.ContainsKey(pos))
                .Select(pos => _mapController.Tiles[pos]).ToList();
            terrains.Add(pair.Value);
            var types = terrains.ToList().Select(terrains => terrains.type).ToList();

            if (types.Contains(TerrainType.Water) && types.Contains(TerrainType.Forest) &&
                types.Contains(TerrainType.Meadows))
            {
                InventoryController.Instance().AddResourceCount(ResourceType.Wood, 1);
            }

            if (types.Contains(TerrainType.Water) && types.Contains(TerrainType.Rock) &&
                types.Contains(TerrainType.Meadows))
            {
                InventoryController.Instance().AddResourceCount(ResourceType.Stone, 1);
            }
        });
    }

    public HashSet<Vector2Int> GetCoastTiles()
    {
        HashSet<Vector2Int> coastTiles = new HashSet<Vector2Int>();
        var tiles = MapController.Instance().Tiles;
        foreach (var tile in tiles.Keys)
        {
            var neighbors = MapController.Instance().GetNeighbors(tile).ToList();
            foreach (var neighbor in neighbors)
            {
                if (tiles.ContainsKey(neighbor))
                {
                    if (tiles[neighbor].type == TerrainType.Water && tiles[tile].type != TerrainType.Water);
                    coastTiles.Add(tile);
                    break;
                }
            }
        }
        return coastTiles;
    }

    class NoNonWaterTilesRemainingException : ApplicationException{}

    public void GenerateRandomWaterOnCoast(int amount)
    {
        for (int i = 0; i < amount; ++i) 
        {
            HashSet<Vector2Int> coastTiles = GetCoastTiles();
            if (coastTiles.Count > 0)
            {
                var randomCoastTile = coastTiles.ToArray()[Random.Range(0, coastTiles.Count-1)];
                MapController.Instance().Tiles[randomCoastTile].type = TerrainType.Water;
            }
            else
            {
                throw new NoNonWaterTilesRemainingException();
            }
        }
    }
}