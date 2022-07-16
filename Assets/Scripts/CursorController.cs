using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CursorController : MonoBehaviour
{
    private static CursorController _instance;

    public static CursorController Instance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    public GameObject cursor;
    public Tilemap Tilemap;
    private Vector2Int _currentPosition;

    private void Update()
    {
        Vector2Int direction = Vector2Int.zero;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction += Vector2Int.up;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction += Vector2Int.down;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction += Vector2Int.left;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction += Vector2Int.right;
        }

        if (direction != Vector2Int.zero)
        {
            _currentPosition += direction;
            centerCursor();
        }
    }

    private void centerCursor()
    {
        var position = Tilemap.GetCellCenterWorld((Vector3Int) _currentPosition);
        cursor.transform.position = position;
    }
}