using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

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

    public void afterPass()
    {
        foreach (TerrainTile element in _mapController.possibleTiles)
        {
            Console.Write($"{element} ");
        }
    }
}