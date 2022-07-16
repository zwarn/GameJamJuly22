using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI
{
    public class SelectionUI : MonoBehaviour
    {
        private static SelectionUI _instance;

        public static SelectionUI Instance()
        {
            return _instance;
        }

        private void Awake()
        {
            _instance = this;
        }

        public SelectionTileUI left;
        public SelectionTileUI right;
        private MapController _mapController;
        private TerrainTile _selectedTile;

        private void Start()
        {
            _mapController = MapController.Instance();
            Events.Instance().MoveMade += Regenerate;
            Regenerate();
        }

        public TerrainTile GETSelectedTile()
        {
            return _selectedTile;
        }

        private void Regenerate()
        {
            left.SetImage(RandomTile());
            right.SetImage(RandomTile());
            left.Selected = true;
            right.Selected = false;
            _selectedTile = left.SelectedTile;
        }

        private TerrainTile RandomTile()
        {
            return _mapController.possibleTiles[Random.Range(0, _mapController.possibleTiles.Length)];
        }

        public void SetSelectedTile(TerrainTile tile)
        {
            _selectedTile = tile;
            left.Selected = left.SelectedTile == tile;
            right.Selected = right.SelectedTile == tile;
        }
    }
}