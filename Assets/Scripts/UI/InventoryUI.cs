using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class InventoryUI : MonoBehaviour
    {
        public TMP_Text stoneText;
        public TMP_Text woodText;

        private InventoryController _inventoryController;

        private void Start()
        {
            _inventoryController = InventoryController.Instance();
            Events.Instance().MoveMade += UpdateCount;
            UpdateCount();
        }


        private void UpdateCount()
        {
            stoneText.text = _inventoryController.GetResourceCount(ResourceType.Stone).ToString();
            woodText.text = _inventoryController.GetResourceCount(ResourceType.Wood).ToString();
        }
    }
}