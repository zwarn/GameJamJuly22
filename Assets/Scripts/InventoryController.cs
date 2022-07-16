using System;
using System.Collections.Generic;
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

    private readonly Dictionary<ResourceType, int> counter = new();

    private void Start()
    {
        counter.Add(ResourceType.Wood, 4);
        counter.Add(ResourceType.Stone, 5);
    }


    public void SetResourceCount(ResourceType type, int count)
    {
        counter[type] = count;
    }

    public void AddResourceCount(ResourceType type, int delta)
    {
        counter[type] += delta;
    }

    public int GetResourceCount(ResourceType type)
    {
        return counter[type];
    }
}