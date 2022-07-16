﻿using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Tile", menuName = "TerrainTile", order = 0)]
public class TerrainTile : ScriptableObject
{
    public TerrainType type;
    public Tile tile;
    public int height;

    public void lowerTerrainHeight()
    {
        --height;
    }
}

[Serializable]
public enum TerrainType
{
    Water,
    Forest,
    Meadows,
    Sand,
    Dirt,
    Rock,
    Swamp,
    Tropics,
    Snow,
}