using System;
using System.Collections;
using System.Collections.Generic;
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

    public void PlaceTile()
    {
        _mapController.ChangeTile(_cursorController.CursorPosition(), _mapController.possibleTiles[0]);
        Events.Instance().Move();
    }

    public void afterPass()
    {
        foreach (TerrainTile element in _mapController.possibleTiles)
        {
            Console.Write($"{element} ");
        }
    }
}