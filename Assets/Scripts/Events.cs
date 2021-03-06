using System;
using UnityEngine;

public class Events : MonoBehaviour
{
    private static Events _instance;

    public static Events Instance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    public event Action MoveMade;

    public void OnMadeMove()
    {
        MoveMade?.Invoke();
    }
}