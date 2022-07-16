using System;
using System.Collections;
using System.Collections.Generic;
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
        _mapController.ChangeTile(tilePosition, SelectionUI.Instance().GETSelectedTile());
        Events.Instance().OnMadeMove();
    }

    public void afterPass()
    {
        foreach (TerrainTile element in _mapController.possibleTiles)
        {
            Console.Write($"{element} ");
        }
    }
}