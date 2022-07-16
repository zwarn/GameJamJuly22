using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Resource", menuName = "Resource", order = 0)]
public class Resource : ScriptableObject
{
    public ResourceType type;
    public Sprite image;
}

[Serializable]
public enum ResourceType
{
    Wood,
    Stone
}