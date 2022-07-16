using System;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private static InventoryController _instance;

    public static InventoryController Instance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }
}