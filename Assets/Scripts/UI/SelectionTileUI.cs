using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class SelectionTileUI : MonoBehaviour, IPointerClickHandler
    {
        private bool _selected;
        public Image SelectionImage;
        public Image tileImage;
        public TerrainTile SelectedTile;

        private void Start()
        {
            tileImage = GetComponent<Image>();
        }

        public bool Selected
        {
            get => _selected;
            set
            {
                SelectionImage.enabled = _selected;
                _selected = value;
            }
        }

        public void SetImage(TerrainTile tile)
        {
            SelectedTile = tile;
            tileImage.sprite = tile.tile.sprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            GetComponentInParent<SelectionUI>().SetSelectedTile(SelectedTile);
        }
    }
}