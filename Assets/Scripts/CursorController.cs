using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
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
    public Tilemap tilemap;
    private Vector2Int _currentPosition;
    private MapController _mapController;

    private void Start()
    {
        _mapController = MapController.Instance();
    }

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameController.Instance().PlaceTile();
        }
    }

    public Vector3 CursorWorldPosition()
    {
        var position = tilemap.GetCellCenterWorld((Vector3Int) _currentPosition);
        position.z = 0;
        return position;
    }

    public Vector2Int CursorPosition()
    {
        return _currentPosition;
    }

    private void centerCursor()
    {
        cursor.transform.position = CursorWorldPosition();
    }

    private void OnDrawGizmos()
    {
        if (_mapController == null)
        {
            return;
        }

        _mapController.GetNeighbors(_currentPosition).ToList().ForEach(tile =>
        {
            Gizmos.DrawSphere(tilemap.GetCellCenterWorld((Vector3Int) tile), 0.3f);
        });
    }
}